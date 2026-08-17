using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Polareum.Api.Indexer;

/// <summary>
/// Indexer API configuration module.
/// </summary>
/// <param name="moduleSection"></param>
public class IndexerWebModule(IConfigurationSection moduleSection) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<IndexerClientOptions>(moduleSection);
		services.AutoAddDependenciesFrom<IndexerWebModule>();
	}

	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

/// <summary>
/// Extends the web application builder with Indexer registration helpers.
/// </summary>
public static class IndexerWebApplicationExtensions
{
	/// <summary>
	/// Adds the Indexer API module.
	/// </summary>
	public static ExtendedWebApplicationBuilder AddIndexerWebModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection)
		=> builder.AddModule(new IndexerWebModule(moduleSection));
}
