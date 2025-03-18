using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using acdm = Academia2.Domain.Models;

namespace Academia2.Data.Postgres.Context
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<acdm.Academia2> Academia2 { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory) // Use o diretório base do projeto
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environment}.json", optional: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DatabasePostGres");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("A conexão com o banco de dados não foi configurada corretamente.");
                }

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
