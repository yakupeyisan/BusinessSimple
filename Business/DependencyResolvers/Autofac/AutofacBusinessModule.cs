using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Module = Autofac.Module;
using Business.Validations;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Custom;
using Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ClaimManager>().As<IClaimService>();
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<AuthManager>().As<IAuthService>();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}
