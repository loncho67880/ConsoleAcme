namespace ConsoleAcme.Repositories
{
    public interface IReadFilesFolder
    {
        Task<List<string>> getFiles(string path);
    }
}
