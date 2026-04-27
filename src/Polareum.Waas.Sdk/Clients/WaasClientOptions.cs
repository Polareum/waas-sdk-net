using Microsoft.Extensions.Configuration;
namespace Polareum.Waas.Sdk.Clients;

/// <summary>
/// Waas client configs
/// </summary>
public class WaasClientOptions
{
	/// <summary>
	/// base url for waas server
	/// </summary>
	[ConfigurationKeyName("base-url")]
	public required string BaseUrl { get; set; } = "waas.polareum.com";
	/// <summary>
	/// api key to be used, if null, no api-key will be used
	/// </summary>
	[ConfigurationKeyName("api-key")]
	public required string? ApiKey { get; set; } = null;
}
