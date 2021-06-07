using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimpleStore.Database.DesignDb
{
    public class SimpleDesignFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            //todo: сделать чтение из файла dbSettigns.json
            var connectionString="Host=localhost;Port=5432;Database=StoreDatabase;Username=postgres;Password=postgres;ApplicationName=SimpleStore";
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseNpgsql(connectionString,
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new StoreContext(optionsBuilder.Options);
        }
    }
}
