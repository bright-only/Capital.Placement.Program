using Capital.Placement.Program.Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Capital.Placement.Program.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationDBContext( IConfiguration config )
        {
            _config = config;
        }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }


        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            var url = _config["CosmosDbSetting:URI"] ?? "";
            var accountKey = _config["CosmosDbSetting:Primary Key"] ?? "";
            var databaseName = _config["CosmosDbSetting:DbName"] ?? "";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseCosmos(url, accountKey, databaseName);
        }

        //map Dbset with entity
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonalInformation>()
                .ToContainer("personalinformations")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<PersonalInformation>()
                .OwnsMany(x => x.CustomQuestions);
        }
    }
}
