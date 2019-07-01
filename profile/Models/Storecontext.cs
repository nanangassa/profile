using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;


namespace profile.Models
{
    public class Storecontext : DbContext
    {
        public Storecontext(DbContextOptions<Storecontext> options)
                : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
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
