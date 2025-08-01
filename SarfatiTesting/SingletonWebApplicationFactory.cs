using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SarfatiTesting;

public class SingletonWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var originalServices = new ServiceCollection();
            foreach (var service in services)
            {
                originalServices.Add(service);
            }

            services.Clear();

            foreach (var service in originalServices)
            {
                var newLifetime = ServiceLifetime.Singleton;
                if (service.ImplementationType != null)
                {
                    services.Add(new ServiceDescriptor(service.ServiceType, service.ImplementationType, newLifetime));
                }
                else if (service.ImplementationFactory != null)
                {
                    services.Add(new ServiceDescriptor(service.ServiceType, service.ImplementationFactory,
                        newLifetime));
                }
                else if (service.ImplementationInstance != null)
                {
                    services.Add(new ServiceDescriptor(service.ServiceType, service.ImplementationInstance));
                }
            }
        });
    }
}