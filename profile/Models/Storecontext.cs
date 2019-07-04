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

        }

      //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            IConfigurationRoot configuration = new ConfigurationBuilder()
    //               .SetBasePath(Directory.GetCurrentDirectory())
    //               .AddJsonFile("appsettings.json")
    //               .Build();
    //            var connectionString = configuration.GetConnectionString("DefaultConnection");
    //            optionsBuilder.UseNpgsql(connectionString);
    //        }
    //    }

            //}


  //      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

   //          => optionsBuilder.UseNpgsql("Host=ec2-54-221-215-228.compute-1.amazonaws.com;Database=d6bejp4l9a71ps;Username=zqfcnlmhuauqhp;Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Pooling=true;sslmode=Require;TrustServerCertificate=True");
    }

}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;

//namespace profile.Models
//{
//    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//    public class Storecontext
//    {
//        private readonly RequestDelegate _next;

//        public Storecontext(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public Task Invoke(HttpContext httpContext)
//        {

//            return _next(httpContext);
//        }
//    }

//    // Extension method used to add the middleware to the HTTP request pipeline.
//    public static class StorecontextExtensions
//    {
//        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<Storecontext>();
//        }
//    }
//}
