namespace ConsoleAcme.Repositories
{
    public interface IReadFiles
    {
        Task<List<string>> getLines(string path);
    }
}
