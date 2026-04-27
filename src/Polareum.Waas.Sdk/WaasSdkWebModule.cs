using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polareum.Waas.Sdk.Clients;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Wallet as a Service SDK configuration module
/// </summary>
/// <param name="moduleSection"></param>
public class WaasSdkWebModule(IConfigurationSection moduleSection) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<WaasClientOptions>(moduleSection);
		services.AutoAddDependenciesFrom<WaasSdkWebModule>();
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
/// <inheritdoc />
public static class ExtendedWebApplicationExtension
{
	/// <summary>
	/// Adds Wallet as a Service SDK module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddWaasSdkWebModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection)
		=> builder.AddModule(new WaasSdkWebModule(moduleSection));
}
