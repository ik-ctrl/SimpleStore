using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using SimpleStore.Database;
using SimpleStore.Database.DAL.Enums;
using SimpleStore.Models.Misc.DbInitializers;

namespace SimpleStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                try
                {
                    var host = CreateHostBuilder(args).Build();
                    using (var scope = host.Services.CreateScope())
                    {
                        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                        using (var context = scope.ServiceProvider.GetRequiredService<StoreContext>())
                        {
                            CheckDbConnection(context);
                            MigrateDataBase(context);
                            CheckingForTestMode(config, context);
                            CheckingForAdmin(context);
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
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось инициализировать логгер:{ex.Message}.");
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

        /// <summary>
        /// Миграция базы данных
        /// </summary>
        /// <param name="context"> Контекст базы данных</param>
        private static void MigrateDataBase(StoreContext context)
        {
            context.Database.Migrate();
        }

        /// <summary>
        /// Проверка на тестовый режим приложения
        /// </summary>
        /// <param name="config">Конфигурациия приложения</param>
        /// <param name="context"> Контекс Базы данных</param>
        private static void CheckingForTestMode(IConfiguration config, StoreContext context)
        {
            var isTestMode = false;
            if (bool.TryParse(config.GetSection("TestMode").Value, out isTestMode))
            {
                if (isTestMode)
                {
                    ClearDatabase(context);
                    var initialers = new List<IInitializer>
                    {
                        new DefaultUserInitializer(),
                        new DefaultProductInitializer(),
                    };

                    foreach (var initializer in initialers)
                    {
                        initializer.Initialize(context);
                    }
                }
            }

        }

        /// <summary>
        /// Проверка наличия роли админа в БД. Если он отсутвует, то добавит дефолтного пользователя
        /// </summary>
        /// <param name="context"></param>
        private static void CheckingForAdmin(StoreContext context)
        {
            var admin = context.Users.FirstOrDefault(user => user.Role.Role.Equals(Role.Admin));
            if (admin == null)
            {
                new DefaultUserInitializer().InitializeDefaultAdmin(context);
            }
        }

        /// <summary>
        /// Очистка базы данных.(Кроме справочных таблиц:Roles)
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        private static void ClearDatabase(StoreContext context)
        {
            if (context.Users.Any())
                context.Users.RemoveRange(context.Users);

            if (context.Products.Any())
                context.Products.RemoveRange(context.Products);
            
            if(context.Users.Any())
                context.Users.RemoveRange(context.Users);
            
            if(context.Orders.Any())
                context.Orders.RemoveRange(context.Orders);
            
            if(context.Reviews.Any())
                context.Reviews.RemoveRange(context.Reviews);
            
            if(context.ProductPhotos.Any())
                context.Reviews.RemoveRange(context.Reviews);

            if (context.Categories.Any())
                context.Categories.RemoveRange(context.Categories);
        }

        /// <summary>
        /// Проверка подключения к базе данных
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        private static void CheckDbConnection(StoreContext context)
        {
            var attempt = 5;
            while (attempt >= 0)
            {
                if (context.Database.CanConnect())
                {
                    return;
                }
                else
                {
                    attempt--;
                }
            }
            throw new Exception("Не удалось подключиться к базе данных");
        }

    }
}
