using HospitalSystem.Application;
using HospitalSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HospitalSystem.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalSystemDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DevConnection"), b => b.MigrationsAssembly("HospitalSystem.Api")),
                ServiceLifetime.Transient);

            services.AddScoped<HospitalSystem.Application.Interfaces.IPersonService, PersonService>();
            services.AddScoped<HospitalSystem.Domain.Interfaces.IPersonRepository,
                HospitalSystem.Infrastructure.Persistance.Repositories.PersonRepository>();

            return services;
        }

    }
}
