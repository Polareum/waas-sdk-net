using Polareum.Waas.Sdk.Clients;


namespace Polareum.Waas.Sdk.Internals;

internal sealed class WaasRequestExecutor(IRestBuilder restBuilder, WaasClientOptions options)
{
	public Task<T> GetAsync<T>(string path, object? query, CancellationToken cancellationToken)
		=> SendAsync<T>(path, query, null, x => x.GetAsync<T>(cancellationToken));

	public Task<T> PostAsync<T>(string path, object? query, object? body, CancellationToken cancellationToken)
		=> SendAsync<T>(path, query, body, x => x.PostAsync<T>(cancellationToken));

	public Task<T> PutAsync<T>(string path, object? body, CancellationToken cancellationToken)
		=> SendAsync<T>(path, null, body, x => x.PutAsync<T>(cancellationToken));

	public Task DeleteAsync(string path, object? query, CancellationToken cancellationToken)
		=> SendAsync(path, query, null, x => x.DeleteAsync(cancellationToken));

	public Task PatchAsync(string path, object? query, object? body, CancellationToken cancellationToken)
		=> PatchWithRestSharpAsync(path, query, body, cancellationToken);

	private async Task<T> SendAsync<T>(
		string path,
		object? query,
		object? body,
		Func<IRestBuilder, Task<T>> send)
	{
		var request = restBuilder
			.ForServiceUrl(options.BaseUrl, path);

		if (options.ApiKey is not null)
			request = request.AddHeader("X-API-Key", options.ApiKey);

		if (query is not null)
			request.AddQueryParameter(query);

		if (body is not null)
			request.WithBody(body);

		return await send(request);
	}

	private async Task SendAsync(
		string path,
		object? query,
		object? body,
		Func<IRestBuilder, Task> send)
	{
		var request = restBuilder
			.ForServiceUrl(options.BaseUrl, path);

		if (options.ApiKey is not null)
			request = request.AddHeader("X-API-Key", options.ApiKey);

		if (query is not null)
			request.AddQueryParameter(query);

		if (body is not null)
			request.WithBody(body);

		await send(request);
	}

	private async Task PatchWithRestSharpAsync(string path, object? query, object? body, CancellationToken cancellationToken)
	{
		var request = new RestRequest(options.BaseUrl.TrimEnd('/') + "/" + path.TrimStart('/'), Method.Patch);

		if (options.ApiKey is not null)
			request = request.AddHeader("X-API-Key", options.ApiKey);

		if (query is not null)
			request.AddObject(query);

		if (body is not null)
			request.AddJsonBody(body);

		var response = await new RestClient().ExecuteAsync(request, cancellationToken);
		if (response.IsSuccessful)
			return;

		throw response.ResponseStatus switch
		{
			ResponseStatus.TimedOut => new RequestTimedOutException(),
			_ => new InvalidResponseFromServerException(),
		};
	}
}
