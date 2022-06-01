using ConsoleAcme.DTOs;
using ConsoleAcme.Entities;
using ConsoleAcme.Repositories;

namespace ConsoleAcme.Bussines
{
    internal class CalculateSameTime : ICalculateSameTime
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CalculateSameTime(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<SameTimeDTO>> Calculate(string path)
        {
            var result = new List<SameTimeDTO>();
            var listEmployees = await _employeeRepository.getEmployees(path);

            foreach (var employee in listEmployees)
            {
                foreach (var employeeCompare in listEmployees)
                {
                    if (employee.Name != employeeCompare.Name && !this.exist(result, $"{employeeCompare.Name}-{employee.Name}"))
                    {
                        int sametimes = this.sameTimes(employee.RegistersTimes, employeeCompare.RegistersTimes);
                        if (sametimes > 0)
                        {
                            result.Add(new SameTimeDTO()
                            {
                                Name = $"{employee.Name}-{employeeCompare.Name}",
                                Times = sametimes
                            });
                        }
                    }
                }
            }
            return result;
        }

        private int sameTimes(List<RegisterTime> registerTimes1, List<RegisterTime> registerTimes2)
        {
            int count = 0;
            foreach (var registerTime in registerTimes1)
            {
                foreach(var registerTime2 in registerTimes2)
                {
                    if(registerTime.Day == registerTime2.Day)
                    {
                        if((registerTime.StartTime >= registerTime2.StartTime && registerTime.StartTime <= registerTime2.EndTime)
                            || (registerTime.EndTime >= registerTime2.StartTime && registerTime.EndTime <= registerTime2.EndTime))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private bool exist(List<SameTimeDTO> list, string nameExist)
        {
            foreach(var sameTime in list)
            {
                if(sameTime.Name == nameExist)
                    return true;
            }
            return false;
        }
    }
}
