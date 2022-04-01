using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Services;
using ResidentalComplexManagment.Infrastructure.Data;
using ResidentalComplexManagment.Infrastructure.Services;

namespace ResidentalComplexManagment.Infrastructure;

public static  class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
       
    }

    public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var useOnlyInMemoryDatabase = false;
        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<AppDBContext>(c =>
               c.UseInMemoryDatabase("Catalog"));

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseInMemoryDatabase("Identity"));
        }
        else
        {
            // use real database
            // Requires LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284
            services.AddDbContext<AppDBContext>(c =>
                c.UseNpgsql(configuration.GetConnectionString("NpgSqlHeroku")));

            // Add Identity DbContext
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
