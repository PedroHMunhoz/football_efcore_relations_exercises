using Microsoft.EntityFrameworkCore;
using NETCoreEFCoreRelationships.Mapper;
using NETCoreEFCoreRelationships.Model;

namespace NETCoreEFCoreRelationships.DAO
{
    public partial class DataContext : DbContext
    {
        private readonly string Server = "YOUR_SERVER";
        private readonly int Port = 3306; //MySQL Port
        private readonly string Schema = "YOUR_SCHEMA_NAME";
        private readonly string User = "YOUR_USER";
        private readonly string Password = "YOUR_PASSWORD";

        public DbSet<Federation> Federations { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = string.Format("server={0};port={1};database={2};uid={3};password={4};", Server, Port, Schema, User, Password);
            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString))
            .UseLowerCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FederationMap());
            modelBuilder.ApplyConfiguration(new ChampionshipMap());
            modelBuilder.ApplyConfiguration(new DivisionMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
        }
    }
}
