//Dependency injection
using ConsoleAcme.Bussines;
using ConsoleAcme.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<ICalculateSameTime, CalculateSameTime>()
            .AddSingleton<IReadFiles, ReadFiles>()
            .AddSingleton<IEmployeeRepository, EmployeeRepository>())
    .Build();

await ScopingAsync(host.Services, "Scope 1");

static async Task ScopingAsync(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    ICalculateSameTime calculate = (CalculateSameTime)provider.GetRequiredService<ICalculateSameTime>();

    var folder = AppDomain.CurrentDomain.BaseDirectory + "Data";
    var path = Path.Combine(folder, "Input2.txt");
    var result = await calculate.Calculate(path);

    foreach (var line in result)
    {
        Console.WriteLine($"{line.Name}:{line.Times}");
    }
}