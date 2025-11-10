namespace Services
{
    public interface IImporterReflectionService
    {
        Task<IReadOnlyCollection<string>> GetImporterAssembliesAsync();
    }
}

