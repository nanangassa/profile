using System;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Models
{

    [Table("users")]
    public class User
    {

        [Key]
        [Required]
        public int userid
        {
            get;
            set;

        }

        [ForeignKey("Standard")]
        [Required]
        public string roleid
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string firstname
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string lastname
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string emailaddress
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string password
        {
            get;
            set;

        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dateofbirth
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string city
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string address
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string postalcode
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string country
        {
            get;
            set;
        }
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
//    public class User
//    {
//        private readonly RequestDelegate _next;

//        public User(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public Task Invoke(HttpContext httpContext)
//        {

//            return _next(httpContext);
//        }
//    }

//    // Extension method used to add the middleware to the HTTP request pipeline.
//    public static class UserExtensions
//    {
//        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<User>();
//        }
//    }
//}
