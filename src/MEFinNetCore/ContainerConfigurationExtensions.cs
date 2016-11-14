using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class ContainerConfigurationExtensions
    {
        public static object AssemblyLoadContext { get; private set; }

        public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration, string path, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return WithAssembliesInPath(configuration, path, null, searchOption);
        }

        public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration, string path, AttributedModelProvider conventions, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            List<System.Reflection.Assembly> assemblyList = new List<System.Reflection.Assembly>();
            var assemblies = Directory.GetFiles(path, "*.dll", searchOption);
            foreach (var item in assemblies)
            {
                assemblyList.Add(System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(item));
            }

            configuration = configuration.WithAssemblies(assemblyList);

            return configuration;
        }
    }
}
