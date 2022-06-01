using ConsoleAcme.DTOs;

namespace ConsoleAcme.Bussines
{
    public interface ICalculateSameTime
    {
        Task<List<SameTimeDTO>> Calculate(string path);
    }
}
