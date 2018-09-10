using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProtoService.SalaryServiceImpl;
using ProtoService.ServiceOptions;


namespace ProtoService
{
    static class Program
    {
        const int Port = 50052;
        static void Main(string[] args)
        {
            BuildWebHost(args).CreateScope().Run();
        }
        private static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, builder) => { builder.AddJsonFile("appsettings.json", false, true); })
                .UseStartup<Startup>()
                .UseGrpc<PaySlipServiceImpl>().Build();
    }
}