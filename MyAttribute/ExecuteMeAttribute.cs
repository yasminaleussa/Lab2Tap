using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Attribute;

namespace MyAttribute 
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMeAttribute : Attribute
    {
        public object[] values;
        public ExecuteMeAttribute(params object[] val)
        {
            this.values = val;
        }
        //[ExecuteMe(2,3,1)]
    }
}
