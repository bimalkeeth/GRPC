using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OBSalaries.SalaryService;

namespace ProtoService.ServiceOptions
{
    public static class GrpcServerExtension
    {
        /// <summary>-----------------------------------------
        /// Entry point for GRPC Startup
        /// </summary>----------------------------------------
        /// <param name="hostBuilder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IWebHostBuilder UseGrpc<T>(this IWebHostBuilder hostBuilder)
            where T : SalaryService.SalaryServiceBase
        {
            return hostBuilder.ConfigureServices(services =>
                {
                    services.AddSingleton<IServer, SalaryServer>(provider =>
                    {
                        var serverOption = provider.GetService<IOptions<ServiceOptions>>().Value;
                        var contract = provider.GetService<T>();
                        var serviceDefinition = SalaryService.BindService(contract);
                        return new SalaryServer(serverOption.Host, serverOption.Port, serviceDefinition);

                    });
                });
        }

        /// <summary>-----------------------------------------
        /// Create Server Scope
        /// </summary>----------------------------------------
        /// <param name="webhost"></param>
        /// <returns></returns>
        public static IWebHost CreateScope(this IWebHost webhost)
        {
            return webhost;
        }

        /// <summary>----------------------------------------
        /// Run GRPC Server 
        /// </summary>---------------------------------------
        /// <param name="webhost"></param>
        /// <returns></returns>
        public static IWebHost RunSalaryServer(this IWebHost webhost)
        {
            var scope = webhost.Services.CreateScope();
            var services = scope.ServiceProvider.GetRequiredService<SalaryService.SalaryServiceBase>();
            var serviceOptions=scope.ServiceProvider.GetRequiredService<IOptions<ServiceOptions>>().Value;

            var serviceDefinition = SalaryService.BindService(services);
            using (var server = new SalaryServer(serviceOptions.Host, serviceOptions.Port, serviceDefinition))
            {
                server.Start();
            }

            return webhost;
        }
    }
}