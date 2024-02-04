using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
#nullable disable
namespace Core.Utilities.Interceptors;
public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList() ?? new();
        var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList() ?? new();
        classAttribute.AddRange(methodAttributes);
        return classAttribute.OrderBy(x => x.Priority).ToArray();
    }
}