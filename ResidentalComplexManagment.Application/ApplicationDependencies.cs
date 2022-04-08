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
        services.AddScoped<IAppartment, AppartmentService>();
        services.AddScoped<IResident, ResidentService>();
        services.AddScoped<IPaymentCofficient, PaymentCoefficientService>();


        return services;
    }
}
