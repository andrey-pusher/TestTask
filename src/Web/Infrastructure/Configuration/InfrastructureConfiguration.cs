using Domain.Interfaces.Exteranal.Repositories;
using Domain.Models.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Web.Infrastructure.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.ConfigureRepositories();

            return services;
        }

        private static IServiceCollection ConfigureDbContext(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TestTaskContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBanksTotalRepository<Guid, BanksTotal>, BanksTotalRepository>();

            return services;
        }
    }
}
