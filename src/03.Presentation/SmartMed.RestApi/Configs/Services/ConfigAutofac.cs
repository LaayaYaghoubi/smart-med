using Autofac;
using Autofac.Extensions.DependencyInjection;
namespace SmartMed.RestApi.Configs.Services;

public static class ConfigAutofac
{
   public static ConfigureHostBuilder AddAutofacConfig(
      this ConfigureHostBuilder builder,
      IConfiguration configuration)
   {
      builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
      builder.ConfigureContainer<ContainerBuilder>(b =>
         b.RegisterModule(new AutofacBusinessModule(configuration))
      );
      return builder;
   }
}