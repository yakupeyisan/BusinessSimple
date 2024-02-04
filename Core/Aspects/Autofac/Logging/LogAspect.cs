using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.Logging;

namespace Core.Aspects.Autofac.Logging;
public class LogAspect : MethodInterception
{

    protected override void OnBefore(IInvocation invocation)
    {
        Debug.WriteLine("Test");
    }
}


public class DebugWriteAspect : MethodInterception
{
    public string Message { get; set; }
    protected override void OnBefore(IInvocation invocation)
    {
        Debug.WriteLine(Message);
    }
}


public class DebugWriteSuccessAspect : MethodInterception
{
    public string Message { get; set; }
    protected override void OnSuccess(IInvocation invocation)
    {
        Debug.WriteLine(Message);
    }
}

