using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Program
    {
        [Import] // default contract is typeof(ICalculator)
        public ICalculator calculator { get; set; } // in order to use MySimpleCalculator class

        public Program()
        {
            //it requires for MySimpleCalculator class load
            var assemblies = new[] { typeof(SimpleCalculator.Program).GetTypeInfo().Assembly };

            //defines path that contains librarys will be loaded dynamically
            var path = @"D:\MyOwnDocuments\MEF in .NET Core\SourceCode\MEFinNetCoreApplication\src\MEFinNetCore\Modules";

            //load assemblies in the path.
            ContainerConfiguration configuration = new ContainerConfiguration()
                .WithAssembliesInPath(path).WithAssemblies(assemblies);

            using (var container = configuration.CreateContainer())
            {
                calculator = container.GetExport<ICalculator>();
            }
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            String s;
            Console.WriteLine("Enter command:");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(p.calculator.Calculate(s));
            }
        }
    }
}
