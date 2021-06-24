using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using SimpleStore.Database;
using SimpleStore.Models.Misc;

namespace SimpleStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //todo: добавить метод для проверки всех необходимых подключений перед запуском
            
            var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<StoreContext>())
                    {
                        context.Database.Migrate();

                        //todo: добавить tryParse потом и вынести метод
                        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                        var isTestMode = Boolean.Parse(config.GetSection("TestMode").Value);
                        if (isTestMode)
                        {
                            //todo: метод для очистки таблиц добавить

                        }
                    }
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Init Error");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .ConfigureLogging(logging =>
                        {
                            logging.ClearProviders();
                            logging.SetMinimumLevel(LogLevel.Error);
                        })
                        .UseNLog();
                });
    }
}
