using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        public Type ValidationType { get; set; }

        public ValidationAspect(Type validationType)
        {
            ValidationType = validationType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
           var validation= ServiceTool.GetService(ValidationType) as BaseValidation;
           validation.Run(invocation.Arguments);

        }
    }
}
