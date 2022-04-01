using Microsoft.Extensions.DependencyInjection;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Services;

namespace ResidentalComplexManagment.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IMTK, MTKService>();
        services.AddScoped<IBuilding, BuildingService>();


        return services;
    }
}
