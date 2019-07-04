using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using profile.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

namespace profile.Models
{
    public class Storecontext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public Storecontext(DbContextOptions<Storecontext> options)
               : base(options)
        {
            //options.Entity<User>().HasKey(u => new { u.Id, u.OrganizationId });
           // options.<User>().Property(x => x.Id).ValueGeneratedOnAdd();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public").ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(modelBuilder);
        }

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
    //=> modelBuilder.ForNpgsqlUseIdentityColumns();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // optionsBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

    }
}

//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

//          => optionsBuilder.UseNpgsql("Host=ec2-54-221-215-228.compute-1.amazonaws.com;Database=d6bejp4l9a71ps;Username=zqfcnlmhuauqhp;Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Pooling=true;sslmode=Require;TrustServerCertificate=True");





