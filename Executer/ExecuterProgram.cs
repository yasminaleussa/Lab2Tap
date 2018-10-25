using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace Executer
{
    class ExecuterProgram
    {
        static void Main(string[] args)
        {
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in a.GetTypes())
            {
                if (type.IsClass)
                    Console.WriteLine(type.FullName);

                foreach (var met in type.GetMethods())
                {
                    Console.WriteLine(met.ToString());
                }
            }
        
            // invoco i metodi publici
            var ClassF = a.GetTypes();
            
            foreach (var classe in ClassF)
            {
                // creo istanza
                var instanceClass = Activator.CreateInstance(classe);
                // creo array di metodo
                MethodInfo[] methodInfos = classe.GetMethods();

                //per ogni metodo creo un custom attribute
                foreach (var met in methodInfos)
                {
                    var att = met.GetCustomAttributes<ExecuteMeAttribute>();
                    foreach (var custom in att)
                    {
                        var par = custom.values;
                        met.Invoke(instanceClass, par);

                    }

                }
            }


            Console.Read();
        }
    }
}
