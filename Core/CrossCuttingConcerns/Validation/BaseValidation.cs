using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation;
public abstract class BaseValidation
{
    //[User user]
    public void Run(object[] arguments)
    {
        var listDefaultMethods=new List<string>(){"GetType","ToString","Equals","Run","GetHashCode","Run"};
        var methods=this.GetType().GetMethods().ToList().Where(m=>!listDefaultMethods.Contains(m.Name)).ToList();
        methods.ForEach(method =>
        {
            var result=(Task)method.Invoke(this, arguments);
            result.Wait();
            
        });
        Debug.WriteLine("Validasyonları çalıştır.");
    }
}
