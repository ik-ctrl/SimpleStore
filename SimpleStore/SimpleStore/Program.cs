using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            
            var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
                    context.Database.Migrate();
                    if (!context.Users.Any())
                    {
                        DefaultUserInitializer.Initialize(context);
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
