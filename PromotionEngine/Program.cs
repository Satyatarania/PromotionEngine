using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PromotionEngine.Business.Service;
using PromotionEngine.DataAccess;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().RunDBScript().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ICalculatorTypeService, CalculatorTypeService>();
                    services.AddTransient<ICalculateService, CalculateService>();
                    services.AddTransient<IFacadeService, FacadeService>();
                    services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("PromotionDatabase"));
                    services.AddHostedService<PromotionEngineInit>();
                })
                .UseConsoleLifetime(o => o.SuppressStatusMessages = true);

            return hostBuilder;
        }
    }
}
