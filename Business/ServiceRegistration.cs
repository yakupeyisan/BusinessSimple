using System;
using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Custom;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class ServiceRegistration
{
	public static void RegisterBusinessServices(this IServiceCollection services)
	{
		//Http request
        services.AddSingleton<ICacheService, MicrosoftCacheManager>();
		services.AddDbContext<BusinessDbContext>();
		//services.AddSingleton<ITokenHelper, JWTTokenHelper>();
		//services.AddScoped<IClaimRepository, ClaimRepository>();
		services.AddScoped<ClaimValidations>();
		//services.AddScoped<IClaimService, ClaimManager>();
		//services.AddScoped<IUserClaimRepository, UserClaimRepository>();
		services.AddScoped<UserValidations>();
		services.AddScoped<IUserRepository, UserRepository>();
		//services.AddScoped<IUserService, UserManager>();
		services.AddScoped<AuthValidations>();
		//services.AddScoped<IAuthService, AuthManager>();
	}
}

