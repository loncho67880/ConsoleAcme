using ConsoleAcme.Entities;

namespace ConsoleAcme.Repositories
{
    public interface IRegisterTimeRepository
    {
        Task<List<RegisterTime>> getRegisterTimes();
    }
}
