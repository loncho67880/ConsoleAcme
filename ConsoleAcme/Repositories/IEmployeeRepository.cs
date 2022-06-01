using ConsoleAcme.Entities;

namespace ConsoleAcme.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> getEmployees(string path);
    }
}
