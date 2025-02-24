using HospitalSystem.Application;
using HospitalSystem.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Add Database Service
//builder.Services.AddDbContext<HospitalSystem.Infrastructure.Persistance.HospitalSystemDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"), 
//    b => b.MigrationsAssembly("HospitalSystem.Api")));


//// Add DI
//builder.Services.AddScoped<HospitalSystem.Application.Interfaces.IPersonService, PersonService>();
//builder.Services.AddScoped<HospitalSystem.Domain.Interfaces.IPersonRepository, 
//    HospitalSystem.Infrastructure.Persistance.Repositories.PersonRepository>();

// Implement Infastructure Dependency Injection 
builder.Services.ImplementPersistance(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
