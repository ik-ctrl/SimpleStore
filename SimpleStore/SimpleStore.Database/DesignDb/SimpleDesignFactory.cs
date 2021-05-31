using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace SimpleStore.Database.DesignDb
{
    public class SimpleDesignFactory:IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            
            var configurationBuilder = new ConfigurationBuilder();

            //todo: до делать билдеры для  миграции
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //IConfigurationRoot config = builder.Build();

            //// получаем строку подключения из файла appsettings.json
            //string connectionString = config.GetConnectionString("DefaultConnection");
            //optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            //return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
