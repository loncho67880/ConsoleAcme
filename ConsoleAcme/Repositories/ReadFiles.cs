namespace ConsoleAcme.Repositories
{
    public class ReadFiles : IReadFiles
    {
        public async Task<List<string>> getLines(string path)
        {
            return (await File.ReadAllLinesAsync(path)).ToList();
        }
    }
}
