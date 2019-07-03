using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

//using DomainModel;
//using DomainModel.Model;

using Newtonsoft.Json;


//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Npgsql;

namespace profile.Controllers
{

   //[Route("api/")]
   // [Route("api/Views")]


    // [Route("Home/Controllers/HomeController")]

    public class HomeController : Controller
    {

        private readonly Storecontext _dataContext;

        public HomeController(Storecontext context)
        {
            _dataContext = context;
        }

        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<User> GetByid(int id)
        //{
        //    var item = _dataContext.Users.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}


        //[HttpGet("{id}")]
        //public User Get(int id)
        //{
        //    return _dataContext.Users.FirstOrDefault(x => x.userid == id);
        //}

        //[HttpPost]
        //public void Post([FromBody]User user)
        //{
        //    _dataContext.Add(user);
        //    _dataContext.SaveChanges();
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]User user)
        //{
        //    var selectedUser = _dataContext.Users.FirstOrDefault(x => x.userid == id);
        //    if (selectedUser != null)
        //    {
        //        _dataContext.Entry(selectedUser).Context.Update(user);
        //        _dataContext.SaveChanges();
        //    }
        //}


        //// POST api/values
        //[HttpPost("{id}")]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataContext.Users;
        }

        //[Route("")]
        // [Route("Home")]
        // [Route("Home/Index")]
        //[Route("Home/Index/{id}")]

        // [Route("/")]     // Doesn't combine, defines the route template ""


        //[HttpGet]
        // [Route("Home/Resume")]
        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

      
       // [Route("Home/About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Application description page.";

            return View();
        }


       // [Route("Home/Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "My contact information page.";

            return View();
        }


      //  [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpGet]// GET: /<controller>
        //[Route("Home/Register")]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost("users")]// GET: /<controller>/
        //  [Route("Home/Register")]
        //  [HttpPost("UserController/{id}")]
        [HttpPost]
        public IActionResult Register(User user)
        {

           // int Userid = Convert.ToInt16(Request.Query["UserId"]);
           // int roleid = Convert.ToInt32(Request.Query["RoleId"]);

            string roleid = Request.Form["RoleId"];
            string firstname = Request.Form["FirtName"].ToString();
            string lastname = Request.Query["LastName"].ToString();
            String emailaddress = Request.Query["EmailAddress"].ToString();
            String password = Request.Query["Password"].ToString();
            String DateOfBirth = Request.Query["DateOfBirth"].ToString();
            String City = Request.Query["City"].ToString();
            String Address = Request.Query["Address"].ToString();
            String PostalCode = Request.Query["PostalCode"].ToString();
            String Country = Request.Query["Country"].ToString();


            User usr = new User();

            if (Request.Query["RoleId"] == "2")

                {
                    user.RoleId = 2;
            }
            else
            {
                user.RoleId = 1;
            }

            // using (var connection = new SqlConnection(connString))
            // {
            //     connection.Execute("INSERT INTO users (roleid, firstname, lastname, emailaddress, password, dateodbirth) VALUES (@FirstName, @LastName, @emailaddress, @password, @dateodbirth)",
            //         new { user.FirstName, user.LastName, user.EmailAddress, user.Password, user.DateOfBirth });
            // }

            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection("Server=ec2-54-221-215-228.compute-1.amazonaws.com;User Id=zqfcnlmhuauqhp; " +
                "Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Database=d6bejp4l9a71ps;sslmode=Require;TrustServerCertificate=True");

            conn.Open();

            // Define a query
            NpgsqlCommand command = new NpgsqlCommand("SELECT (emailaddress, password) FROM users WHERE emailaddress=emailaddress AND password=password", conn);


            //string sql = "INSERT INTO Customers (FirstName,LastName) VALUES ('Test','Tube')";

            //using (var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES (@p)", conn))
            //{
            //    cmd.Parameters.AddWithValue("p", "some_value");
            //    cmd.ExecuteNonQuery();
            //}

            // Execute the query and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            //NpgsqlDataReader dr2 = command2.ExecuteReader();

            // Output rows
            //while (dr.Read())
            //  Console.Write("{0}\t{1} \n", dr[0], dr[1]);

            //var existing = (from users in _dataContext.Users where (users.EmailAddress == user.EmailAddress) select users).FirstOrDefault();
            //string existing = "SELECT emailaddress FROM users WHERE emailaddress = 'existing'";

            if (dr.HasRows)
            {
                dr.Read();
                // usr.EmailAddress = dr["EmailAddress"].ToString();
                if (dr[0].ToString() == emailaddress && dr[1].ToString() == password)
                {
                    RedirectToAction("Register");
                }
            }
            else
            {

                //NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO users (Roleid,FirstName,LastName,EmailAddress,Password,DateOfBirth,City,Address,PostalCode, Country) VALUES (@roleid,@firstname,@lastname,@emailaddress,@password,@DateOfBirth,@City,@Address,@PostalCode,@Country", conn);
                // NpgsqlDataReader dr2 = command2.ExecuteReader(new { roleid, firstname, lastname, emailaddress, password, DateOfBirth, City, Address, PostalCode, Country });
                conn.Execute("insert into users (Roleid,FirstName,LastName,EmailAddress,Password,DateOfBirth,City,Address,PostalCode, Country) values (@roleid,@firstname,@lastname,@emailaddress,@password,@DateOfBirth,@City,@Address,@PostalCode,@Country)", new { roleid, firstname, lastname, emailaddress, password, DateOfBirth, City, Address, PostalCode, Country });

                //var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES (@p)", conn);

               // NpgsqlDataReader dr2 = command2.ExecuteReader();
                conn.Close();

                //if (command == null) // ex
                //{
                //    _dataContext.Users.Add(user);
                //    _dataContext.SaveChanges();
                //}

            }
            return RedirectToAction("Login");

        }


        [HttpGet]// GET: /<controller>/
       // [Route("Home/Login")]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]// GET: /<controller>/
        //[Route("Home/Login")]
        public IActionResult LogIn(User user)
        {
            //This the line that throws the exception.

            //   HttpContext.Session.SetInt32("UserId", user.UserId);

            //return View();

             return RedirectToAction("Index");
        }

        // [HttpGet("/api/Users/{id}")]
        //[HttpPost("AuthenticateUser/{id}")]//("Home/Index/{id}")]
        //  [Route("Home/Login/{id}")]
        // [Route("Home/Login")]
        // [Route("Home/Index")]
        [HttpPost]
        public IActionResult AuthenticateUser()
        {
            string email = Request.Query["EmailAddress"];
            string pass = Request.Query["Password"];
            User usr = new User();

            // var user = (from u in _dataContext.Users where (u.EmailAddress == email && u.Password == pass) select u).FirstOrDefault();
            // selectedUser = _dataContext.Users.FirstOrDefault(x => x.userid == id);


            // string user = "SELECT emailAddress FROM simple_table WHERE emailAddress = 'email' AND password = 'pass'";

            NpgsqlConnection conn = new NpgsqlConnection("Server=ec2-54-221-215-228.compute-1.amazonaws.com;User Id=zqfcnlmhuauqhp; " +
                "Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Database=d6bejp4l9a71ps;sslmode=Require;TrustServerCertificate=True");

            conn.Open();

            // Define a query
            NpgsqlCommand command = new NpgsqlCommand("SELECT emailaddress, password FROM users WHERE emailaddress=:email AND password=:pass;", conn);

            // Execute the query and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

           // if (dr[0] == null)
           //     return Redirect("Login");   //

            if (dr.HasRows)
            {
                dr.Read();
                
                    // usr.EmailAddress = dr["EmailAddress"].ToString();
                    if (dr[0].ToString() == email && dr[1].ToString() == pass)
                    {
                        RedirectToAction("Index");
                    }
                
            }

            // Output rows
            //  while (dr.Read())
            //     Console.Write("{0}\t{1} \n", dr[0], dr[1]);

            conn.Close();


            return RedirectToAction("Login");
        }

    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // [Route("")]
       // [Route("Home")]
       // [Route("Home/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
