using Microsoft.Extensions.Configuration;

namespace Polareum.Api.Indexer;

/// <summary>
/// Indexer client configuration.
/// </summary>
public class IndexerClientOptions
{
	/// <summary>
	/// Base URL for the Indexer server.
	/// </summary>
	[ConfigurationKeyName("base-url")]
	public required string BaseUrl { get; set; } = "indexer.polareum.com";

	/// <summary>
	/// API key to be used. If null, no API key will be sent.
	/// </summary>
	[ConfigurationKeyName("api-key")]
	public required string? ApiKey { get; set; }
}
