using BusinessRules.Managers;
using BusinessRules.Rules;
using ContractModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ProtoService.DependencyConfiguration
{
    public static class DiConfiguration
    {
        /// <summary>------------------------------------------
        /// Business logic interface dependency Injection 
        /// </summary>-----------------------------------------
        /// <param name="services"></param>
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IPaySlipManager,PaySlipManager>();
            services.AddTransient<IRuleFactory, RuleFactory>();
            services.AddTransient<IRuleFactory, RuleFactory>();
        }
        
    }
}