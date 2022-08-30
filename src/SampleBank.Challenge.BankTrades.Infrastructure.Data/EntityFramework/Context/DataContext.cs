using SampleBank.Challenge.BankTrades.Infra.Data.Mappings;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace SampleBank.Challenge.BankTrades.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Client> People { get; set; }
        public DbSet<Trade> Trades { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string projectPath = $@"{AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"src\" }, StringSplitOptions.None)[0]}src\SampleBank.Challenge.BankTrades.API\";
            IConfigurationRoot configuration = new ConfigurationBuilder() 
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
        
            if (!options.IsConfigured)
            {
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new TradeMap());
        }
    }
}
