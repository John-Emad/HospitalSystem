using HospitalSystem.Application;
using HospitalSystem.Application.Services;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HospitalSystem.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection InjectingInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalSystemDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DevConnection"), b => b.MigrationsAssembly("HospitalSystem.Api")),
                ServiceLifetime.Transient);
            
            #region PersonServices
            services.AddScoped<Application.Interfaces.IPersonService, PersonService>();
            services.AddScoped<Domain.Interfaces.IPersonRepository,
                Persistance.Repositories.PersonRepository>();
            #endregion

            #region PatientServices
            services.AddScoped<Application.Interfaces.IPatientService, PatientService>();
            services.AddScoped<Domain.Interfaces.IPatientRepository,
                Persistance.Repositories.PatientRepository>();
            #endregion

            #region TokenServices
            services.AddScoped<Application.Interfaces.ITokenService, TokenService>();
            services.AddScoped<Domain.Interfaces.ITokenRepository,
                Persistance.Repositories.TokenRepository>();
            #endregion

            services.AddIdentityCore<Person>()
                .AddEntityFrameworkStores<HospitalSystemDBContext>();



            return services;
        }

    }
}
