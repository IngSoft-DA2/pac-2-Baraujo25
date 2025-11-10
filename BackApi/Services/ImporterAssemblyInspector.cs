using System.Reflection;
using System.Runtime.Loader;

namespace Services
{
    internal static class ImporterAssemblyInspector
    {
        public static bool ContainsImplementation<TInterface>(string assemblyPath, out bool treatAsMatch)
            where TInterface : class
        {
            treatAsMatch = false;

            try
            {
                var assembly = LoadAssembly(assemblyPath);

                return assembly
                    .GetTypes()
                    .Any(type => type.IsClass &&
                                 type.IsPublic &&
                                 !type.IsAbstract &&
                                 typeof(TInterface).IsAssignableFrom(type));
            }
            catch (FileLoadException)
            {
                treatAsMatch = true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private static Assembly LoadAssembly(string path)
        {
            var assemblyName = AssemblyName.GetAssemblyName(path);

            var alreadyLoaded = AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(a => AssemblyName.ReferenceMatchesDefinition(a.GetName(), assemblyName));

            if (alreadyLoaded is not null)
            {
                return alreadyLoaded;
            }

            return AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
        }
    }
}

