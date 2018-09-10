using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OBSalaries.SalaryService;
using ProtoService.DependencyConfiguration;
using ProtoService.SalaryServiceImpl;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace ProtoService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        /// <summary>----------------------------------------------
        /// Configuring and Initializing Grpc Service with base
        /// </summary>---------------------------------------------
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SalaryService.SalaryServiceBase, PaySlipServiceImpl>();
            services.AddSingleton<PaySlipServiceImpl, PaySlipServiceImpl>();
            DiConfiguration.Config(services);
            services.Configure<ServiceOptions.ServiceOptions>(Configuration.GetSection("Service"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }
    }
}