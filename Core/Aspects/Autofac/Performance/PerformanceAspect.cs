using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;

namespace Core.Aspects.Autofac.Performance;
public class PerformanceAspect:MethodInterception
{
    public int _interval;
    public Stopwatch _stopwatch { get; set; }
    public PerformanceAspect(int interval)
    {
        _interval = interval;
        _stopwatch = ServiceTool.GetService<Stopwatch>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _stopwatch.Start();
    }

    protected override void OnAfter(IInvocation invocation)
    {
        if (_stopwatch.Elapsed.TotalSeconds > _interval)
        {
            Debug.WriteLine($"Performance: {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} ===> {_stopwatch.Elapsed.TotalSeconds} ");
        }
        _stopwatch.Stop();
        _stopwatch.Reset();
    }
}

