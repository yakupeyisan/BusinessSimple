using Business.Validations;
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public class BusinessServiceModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddScoped<AddUserValidations>();
        services.AddScoped<UpdateUserValidations>();
        services.AddScoped<ClaimValidations>();
        services.AddScoped<AuthValidations>();
        services.AddScoped<DeleteValidations>();
    }
}

