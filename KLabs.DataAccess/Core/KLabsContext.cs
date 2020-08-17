using System;
using System.IO;
using System.Linq;
using KLabs.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace KLabs.DataAccess.Core
{
    public class KLabsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true);

            IConfigurationRoot _configuration = config.Build();
            optionsBuilder.UseSqlServer(_configuration["SqlConnectionString"]);
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<AboutUs> AboutUses { get; set; }

        public DbSet<LoginLog> LoginLogs { get; set; }

        public DbSet<Privacy> Privacies { get; set; }

        public DbSet<Reference> References { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Solution> Solutions { get; set; }


    }
}