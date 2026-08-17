using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Polareum.Api.Waas;

/// <summary>
/// Wallet as a Service API configuration module.
/// </summary>
/// <param name="moduleSection"></param>
public class WaasWebModule(IConfigurationSection moduleSection) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<WaasClientOptions>(moduleSection);
		services.AutoAddDependenciesFrom<WaasWebModule>();
	}

	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

/// <summary>
/// Extends the web application builder with WAAS registration helpers.
/// </summary>
public static class WaasWebApplicationExtensions
{
	/// <summary>
	/// Adds the Wallet as a Service API module.
	/// </summary>
	public static ExtendedWebApplicationBuilder AddWaasWebModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection)
		=> builder.AddModule(new WaasWebModule(moduleSection));
}
