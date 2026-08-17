namespace Polareum.Api.Indexer;

/// <summary>
/// Provides the root entry point for calling Indexer Server APIs.
/// </summary>
public interface IIndexerClient
{
	/// <summary>Gets management APIs.</summary>
	IIndexerManagementClient Management { get; }

	/// <summary>Gets webhook APIs.</summary>
	IIndexerWebhooksClient Webhooks { get; }
}

/// <summary>
/// Provides Indexer management APIs.
/// </summary>
public interface IIndexerManagementClient
{
	/// <summary>Calls the management endpoint.</summary>
	Task<string> GetAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Provides Indexer webhook APIs.
/// </summary>
public interface IIndexerWebhooksClient
{
	/// <summary>Registers a webhook and returns its identifier.</summary>
	Task<string> RegisterAsync(RegisterWebhookRequest request, CancellationToken cancellationToken = default);

	/// <summary>Unregisters a webhook.</summary>
	Task UnregisterAsync(UnregisterWebhookRequest request, CancellationToken cancellationToken = default);
}
