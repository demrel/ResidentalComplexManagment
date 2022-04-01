using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Services;
using ResidentalComplexManagment.Infrastructure.Data;
using ResidentalComplexManagment.Infrastructure.Services;
using ResidentalComplexManagment.Web.Services;

namespace ResidentalComplexManagment.Web.DependencyHelper;
public static  class WebDependencies
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();


        return services;
       
    }

 
}
