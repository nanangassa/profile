using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile.Models;

namespace profile.Controllers
{
    public class HomeController : Controller
    {

        private Storecontext _dataContext;


        public HomeController(Storecontext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]// GET: /<controller>/
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]// GET: /<controller>/
        public IActionResult LogIn(User user)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AuthenticateUser()
        {
            String email = Request.Form["EmailAddress"];
            String pass = Request.Form["Password"];

            var user = (from u in _dataContext.Users where (u.EmailAddress == email && u.Password == pass) select u).FirstOrDefault();

            if (user == null)
                return RedirectToAction("Login");

            if (user.Password != pass)
                return RedirectToAction("Login");

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                HttpContext.Session.SetString("FN", user.FirstName);
                HttpContext.Session.SetString("LN", user.LastName);
                HttpContext.Session.SetString("Password", user.Password);

            }

            return RedirectToAction("Index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
