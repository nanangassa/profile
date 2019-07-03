using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

       // [ForeignKey("Standard")]
        [Required]
        public int RoleId
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string EmailAddress
        {
            get;
            set;

        }

        [Required]
        [StringLength(50)]
        public string Password
        {
            get;
            set;

        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string City
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string Address
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string PostalCode
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string Country
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
