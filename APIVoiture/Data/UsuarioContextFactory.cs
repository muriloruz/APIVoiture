using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using APIVoiture.Data;           // namespace onde está UsuarioContext
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace APIVoiture.Data
{
    public class UsuarioContextFactory
        : IDesignTimeDbContextFactory<UsuarioContext>
    {
        public UsuarioContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var cs = config.GetConnectionString("ConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<UsuarioContext>();
            optionsBuilder.UseMySql(
                cs,
                ServerVersion.AutoDetect(cs)
            );

            return new UsuarioContext(optionsBuilder.Options);
        
        }
    }
}

