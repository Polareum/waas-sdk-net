using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polareum.Api.Indexer.Internals;

namespace Polareum.Api.Indexer;

/// <summary>
/// Concrete Indexer client.
/// </summary>
[AutoInjectScoped<IIndexerClient>]
public sealed class IndexerClient : IIndexerClient
{
	/// <summary>
	/// Creates an Indexer client for the given server URL and API key.
	/// </summary>
	public IndexerClient(IRestBuilder restBuilder, IOptions<IndexerClientOptions> options)
	{
		var executor = new IndexerRequestExecutor(restBuilder, options.Value);
		Management = new IndexerManagementClient(executor);
		Webhooks = new IndexerWebhooksClient(executor);
	}

	/// <inheritdoc />
	public IIndexerManagementClient Management { get; }

	/// <inheritdoc />
	public IIndexerWebhooksClient Webhooks { get; }
}

internal sealed class IndexerManagementClient(IndexerRequestExecutor executor) : IIndexerManagementClient
{
	public Task<string> GetAsync(CancellationToken cancellationToken = default)
		=> executor.GetAsync<string>("api/Management", null, cancellationToken);
}

internal sealed class IndexerWebhooksClient(IndexerRequestExecutor executor) : IIndexerWebhooksClient
{
	public Task<string> RegisterAsync(RegisterWebhookRequest request, CancellationToken cancellationToken = default)
		=> executor.PostPlainTextAsync<string>(
			$"{request.Network}/webhooks/register",
			new
			{
				expiryTimeSpan = request.ExpiryTimeSpan,
				webhookAddress = request.WebhookAddress,
			},
			request.GraphqlQuery,
			cancellationToken);

	public Task UnregisterAsync(UnregisterWebhookRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync(
			$"{request.Network}/webhooks/unregister",
			new { id = request.Id },
			null,
			cancellationToken);
}
