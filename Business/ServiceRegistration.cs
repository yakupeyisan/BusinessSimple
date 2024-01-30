using System;
using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class ServiceRegistration
{
	public static void RegisterBusinessServices(this IServiceCollection services)
	{
		services.AddDbContext<BusinessDbContext>();
		services.AddScoped<UserValidations>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUserService, UserManager>();
    }
}

