using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Aspects.Autofac.Security;
using Core.Utilities.Tools;

namespace Business;

public static class BusinessRoleManager
{
    public static void AddSystemRoles()
    {
        var claimService=ServiceTool.GetService<IClaimService>();
        var assembly = Assembly.GetAssembly(typeof(BusinessRoleManager));
        var classList = assembly.GetTypes().ToList()
            .Where(t => t.GetCustomAttributes(typeof(HandleSecurity)).ToList().Count > 0).ToList();
        classList.ForEach(c =>
        {
            var implementedInterface=c.GetInterfaces().First();
            c.GetMethods().ToList()
                .Where(m=>m.GetCustomAttributes<SecurityAspect>().Count()>0).ToList()
                .ForEach(m =>
                {
                    string role = $"{implementedInterface.Name}.{m.Name}";
                    var checkRole=claimService.GetByGroupAndName(implementedInterface.Name, m.Name);
                    if (checkRole == null)
                        claimService.Add(new() { Group = implementedInterface.Name, Name = m.Name });
                    Debug.WriteLine(role);
                });
        });
    }
}
