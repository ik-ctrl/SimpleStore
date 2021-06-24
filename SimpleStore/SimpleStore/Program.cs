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
            //todo: �������� ����� ��� �������� ���� ����������� ����������� ����� ��������
            
            var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<StoreContext>())
                    {
                        context.Database.Migrate();

                        //todo: �������� tryParse ����� � ������� �����
                        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                        var isTestMode = Boolean.Parse(config.GetSection("TestMode").Value);
                        if (isTestMode)
                        {
                            //todo: ����� ��� ������� ������ ��������

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
