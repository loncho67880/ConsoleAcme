using ConsoleAcme.Entities;
using ConsoleAcme.Helpers;

namespace ConsoleAcme.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IReadFiles _readFiles;
        public EmployeeRepository(IReadFiles readFiles)
        {
            _readFiles = readFiles;
        }

        public async Task<List<Employee>> getEmployees(string path)
        {
            List<Employee> result = new List<Employee>();
            List<string> listLines = new List<string>();
            listLines.AddRange(await _readFiles.getLines(path));
            foreach (var line in listLines)
            {
                var linesplit = line.Split(Constant.SEPARATENAME);
                if (linesplit.Length < 2)
                    throw new Exception("Bad file information");

                result.Add(this.getRegisterTime(linesplit));
            }
            return result;
        }

        private Employee getRegisterTime(string[] linesplit)
        {
            var employee = new Employee();
            string name = linesplit[0];
            employee = new Employee();
            employee.Name = name;
            employee.RegistersTimes = new List<RegisterTime>();
            string linetime = linesplit[1];
            if (!string.IsNullOrEmpty(linetime))
            {
                var times = linetime.Split(Constant.SEPARATETIMES);
                foreach (var time in times)
                {
                    var splitTime = time.Split(Constant.SEPARATETIMESPAN);
                    if (linesplit.Length < 2)
                        throw new Exception("Bad time information");
                    employee.RegistersTimes.Add(new RegisterTime()
                    {
                        Day = splitTime[0].Substring(0,2),
                        StartTime = DateUtility.getTime(splitTime[0].Substring(2, 5)),
                        EndTime = DateUtility.getTime(splitTime[1].Substring(0, 5))
                    });
                }
            }
            return employee;
        }
    }
}
