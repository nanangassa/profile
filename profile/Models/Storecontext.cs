using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace profile.Models
{
    public class Storecontext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
         public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BadWord> BadWords { get; set; }


        public Storecontext(DbContextOptions<Storecontext> options)
               //: base(options)
               : base (options)
        {
            //options.Entity<User>().HasKey(u => new { u.Id, u.OrganizationId });
           // options.<User>().Property(x => x.Id).ValueGeneratedOnAdd();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(modelBuilder);

            //var user = modelBuilder.Entity<User>().ToTable("users");
        }
 
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





