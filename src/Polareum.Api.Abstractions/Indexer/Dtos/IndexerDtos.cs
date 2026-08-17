namespace Polareum.Api.Indexer;

/// <summary>
/// Request to register an Indexer webhook.
/// </summary>
public record RegisterWebhookRequest(string Network, TimeSpan ExpiryTimeSpan, string WebhookAddress, string GraphqlQuery);

/// <summary>
/// Request to unregister an Indexer webhook.
/// </summary>
public record UnregisterWebhookRequest(string Network, string Id);
