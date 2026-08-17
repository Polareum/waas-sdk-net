using Polareum.Api.Indexer;

namespace Polareum.Api.Indexer.Internals;

internal sealed class IndexerRequestExecutor(IRestBuilder restBuilder, IndexerClientOptions options)
{
	public Task<T> GetAsync<T>(string path, object? query, CancellationToken cancellationToken)
		=> SendAsync<T>(path, query, null, x => x.GetAsync<T>(cancellationToken));

	public Task<T> PostAsync<T>(string path, object? query, object? body, CancellationToken cancellationToken)
		=> SendAsync<T>(path, query, body, x => x.PostAsync<T>(cancellationToken));

	public Task PostAsync(string path, object? query, object? body, CancellationToken cancellationToken)
		=> SendWithoutResponseAsync(path, query, body, cancellationToken);

	public Task<T> PostPlainTextAsync<T>(string path, object? query, string body, CancellationToken cancellationToken)
		=> PostPlainTextWithRestSharpAsync<T>(path, query, body, cancellationToken);

	private async Task<T> SendAsync<T>(
		string path,
		object? query,
		object? body,
		Func<IRestBuilder, Task<T>> send)
	{
		var request = restBuilder
			.ForServiceUrl(options.BaseUrl, path);

		if (!string.IsNullOrWhiteSpace(options.ApiKey))
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

		if (!string.IsNullOrWhiteSpace(options.ApiKey))
			request = request.AddHeader("X-API-Key", options.ApiKey);

		if (query is not null)
			request.AddQueryParameter(query);

		if (body is not null)
			request.WithBody(body);

		await send(request);
	}

	private async Task SendWithoutResponseAsync(string path, object? query, object? body, CancellationToken cancellationToken)
	{
		await SendAsync<object?>(
			path,
			query,
			body,
			x => x.PostAsync<object?>(cancellationToken));
	}

	private async Task<T> PostPlainTextWithRestSharpAsync<T>(string path, object? query, string body, CancellationToken cancellationToken)
	{
		var request = new RestRequest(options.BaseUrl.TrimEnd('/') + "/" + path.TrimStart('/'), Method.Post);

		if (!string.IsNullOrWhiteSpace(options.ApiKey))
			request = request.AddHeader("X-API-Key", options.ApiKey);

		if (query is not null)
			request.AddObject(query);

		request.AddStringBody(body, ContentType.Plain);

		var response = await new RestClient().ExecuteAsync<T>(request, cancellationToken);
		if (response.IsSuccessful && response.Data is not null)
			return response.Data;

		throw response.ResponseStatus switch
		{
			ResponseStatus.TimedOut => new RequestTimedOutException(),
			_ => new InvalidResponseFromServerException(),
		};
	}
}
