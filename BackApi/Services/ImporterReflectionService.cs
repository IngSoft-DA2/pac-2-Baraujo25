using IImporter;

namespace Services
{
    public class ImporterReflectionService : IImporterReflectionService
    {
        private readonly string _reflectionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reflection");

        public Task<IReadOnlyCollection<string>> GetImporterAssembliesAsync()
        {
            var matchingAssemblies = new List<string>();

            if (!Directory.Exists(_reflectionPath))
            {
                return Task.FromResult((IReadOnlyCollection<string>)Array.Empty<string>());
            }

            var directory = new DirectoryInfo(_reflectionPath);
            var dllFiles = directory.GetFiles("*.dll");

            foreach (var dllFile in dllFiles)
            {
                var assemblyName = Path.GetFileNameWithoutExtension(dllFile.Name);

                var contains = ImporterAssemblyInspector.ContainsImplementation<ImporterInterface>(dllFile.FullName, out var treatAsMatch);

                if (contains || treatAsMatch)
                {
                    matchingAssemblies.Add(assemblyName);
                }
            }

            var distinctAssemblies = matchingAssemblies
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            return Task.FromResult((IReadOnlyCollection<string>)distinctAssemblies);
        }
    }
}

