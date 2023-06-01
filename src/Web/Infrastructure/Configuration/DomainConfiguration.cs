using Domain.Interfaces.Wrappers;
using Domain.Models.Entities;
using Domain.Models.ViewModels;
using Domain.Wrappers;

namespace Web.Infrastructure.Configuration
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.ConfigureWrappers();

            return services;
        }

        private static IServiceCollection ConfigureWrappers(this IServiceCollection services)
        {
            services.AddTransient<IBanksTotalWrapper<Guid, BanksTotalViewModel>, BanksTotalWrapper>();

            return services;
        }
    }
}
