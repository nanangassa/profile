using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using profile.ViewModels;

using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

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

        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog(BlogPostViewModel IndexModel)
        {

            IndexModel.BlogPosts = _dataContext.BlogPosts.ToList();

            try
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId)"));
                if (userId != 0)
                {
                    //    IndexModel.User = _dataContext.Users.Where(s => s.UserId == userId).FirstOrDefault;
                    //where s.UserId.Equals(userId)
                    //select s;
                    IndexModel.User = (from m in _dataContext.Users where m.userid == userId select m).FirstOrDefault();
                    //IndexModel.User = _dataContext.Users.FirstOrDefault(o => o.userid == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Put your error message here.", ex);

            }
            return View(IndexModel);
        }



      
       // [Route("Home/About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Application description page.";

            return View();
        }

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

            string roleid = Request.Query["roleid"].ToString();
            string firstname = Request.Form["firstname"].ToString();
            string lastname = Request.Form["lastname"].ToString();
            string emailaddress = Request.Form["emailaddress"].ToString();
            string password = Request.Form["password"].ToString();
            string DateOfBirth = Request.Form["dateofbirth"].ToString();
            string City = Request.Form["city"].ToString();
            string Address = Request.Form["address"].ToString();
            string PostalCode = Request.Form["postalcode"].ToString();
            string Country = Request.Query["country"].ToString();


            User usr = new User();

            if (Request.Query["RoleId"] == "2")

                {
                    user.roleid = "2";
            }
            else
            {
                user.roleid = "1";
            }

            // using (var connection = new SqlConnection(connString))
            // {
            //     connection.Execute("INSERT INTO users (roleid, firstname, lastname, emailaddress, password, dateodbirth) VALUES (@FirstName, @LastName, @emailaddress, @password, @dateodbirth)",
            //         new { user.FirstName, user.LastName, user.EmailAddress, user.Password, user.DateOfBirth });
            // }

            // Connect to a PostgreSQL database
          //  NpgsqlConnection conn = new NpgsqlConnection("Server=ec2-54-221-215-228.compute-1.amazonaws.com;User Id=zqfcnlmhuauqhp; " +
          //      "Password=c005edf20ff818f232b700c356d150cb5200f05667724608ca661345ca319b7c;Database=d6bejp4l9a71ps;sslmode=Require;TrustServerCertificate=True");

         //   conn.Open();

            // Define a query
         //   NpgsqlCommand command = new NpgsqlCommand("SELECT (emailaddress, password) FROM users WHERE emailaddress=emailaddress AND password=password", conn);


            //string sql = "INSERT INTO Customers (FirstName,LastName) VALUES ('Test','Tube')";

            //using (var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES (@p)", conn))
            //{
            //    cmd.Parameters.AddWithValue("p", "some_value");
            //    cmd.ExecuteNonQuery();
            //}

            // Execute the query and obtain a result set
           // NpgsqlDataReader dr = command.ExecuteReader();
            //NpgsqlDataReader dr2 = command2.ExecuteReader();

            // Output rows
            //while (dr.Read())
            //  Console.Write("{0}\t{1} \n", dr[0], dr[1]);

            var existing = (from users in _dataContext.Users where (users.emailaddress == user.password) select users).FirstOrDefault();
          

                if (existing == null) // ex
                {
                    _dataContext.Users.Add(user);
                    _dataContext.SaveChanges();
                }

           // }
            return RedirectToAction("Login");

            //string existing = "SELECT emailaddress FROM users WHERE emailaddress = 'existing'";

            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    // usr.EmailAddress = dr["EmailAddress"].ToString();
            //    if (dr[0].ToString() == emailaddress && dr[1].ToString() == password)
            //    {
            //        RedirectToAction("Register");
            //    }
            //}
            //else
            //{

            //NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO users (Roleid,FirstName,LastName,EmailAddress,Password,DateOfBirth,City,Address,PostalCode, Country) VALUES (@roleid,@firstname,@lastname,@emailaddress,@password,@DateOfBirth,@City,@Address,@PostalCode,@Country", conn);
            // NpgsqlDataReader dr2 = command2.ExecuteReader(new { roleid, firstname, lastname, emailaddress, password, DateOfBirth, City, Address, PostalCode, Country });
            // conn.Execute("insert into users (Roleid,FirstName,LastName,EmailAddress,Password,DateOfBirth,City,Address,PostalCode, Country) values (@roleid,@firstname,@lastname,@emailaddress,@password,@DateOfBirth,@City,@Address,@PostalCode,@Country)", new { roleid, firstname, lastname, emailaddress, password, DateOfBirth, City, Address, PostalCode, Country });

            //var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES (@p)", conn);

            // NpgsqlDataReader dr2 = command2.ExecuteReader();
            //  conn.Close();

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

             return RedirectToAction("Blog");
        }

        //[HttpPost("AuthenticateUser/{id}")]//("Home/Index/{id}")]
        [HttpPost]
        public IActionResult AuthenticateUser()
        {

            string email = Request.Form["EmailAddress"];
            string pass = Request.Form["Password"];

            var user = (from u in _dataContext.Users where (u.emailaddress == email && u.password == pass) select u).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.userid);
                HttpContext.Session.SetString("RoleId", user.roleid);
                HttpContext.Session.SetString("FN", user.firstname);
                HttpContext.Session.SetString("LN", user.lastname);
                HttpContext.Session.SetString("Password", user.password);
                return RedirectToAction("Blog");


            }
            return RedirectToAction("Login");
        }


        public IActionResult EditBlogPost(int id)
        {
            HttpContext.Session.SetInt32("editBlogId", id);
            var editPost = (from b in _dataContext.BlogPosts where b.blogpostid == id select b).FirstOrDefault();
            return View(editPost);
        }

        [HttpPost]
        public IActionResult EditBlogPost(BlogPost posts)
        {

            int id = Convert.ToInt32(Request.Form["blogpostid"]);
            var postUpdate = (from m in _dataContext.BlogPosts where m.blogpostid == id select m).FirstOrDefault();
            postUpdate.title = posts.title;
            postUpdate.content = posts.content;
            postUpdate.posted = posts.posted;
            postUpdate.shortdescription = posts.shortdescription;

            //save changes to edits
            _dataContext.SaveChanges();
            return RedirectToAction("Blog");
        }

        public IActionResult AddBlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlogPost(BlogPost blogPost)
        {

          //..blogPost = new BlogPost();
            if (HttpContext.Session.GetInt32("UserId") != null)
            {

               // blogPost.blogpostid = Request.Form["blogpostid"].;
                blogPost.content = Request.Form["content"].ToString();
                blogPost.title = Request.Form["title"].ToString();
                blogPost.posted = Convert.ToDateTime(DateTime.Now);
                blogPost.userid = (int)(HttpContext.Session.GetInt32("UserId"));
                blogPost.shortdescription = Request.Form["shortdescription"].ToString();
               // blogPost.isavailable = Request.Form["isavailable"].ToString();

                if (blogPost != null)
                {
                    _dataContext.BlogPosts.Add(blogPost);
                    _dataContext.SaveChanges();
                }
            }
            return RedirectToAction("Blog");
        }

        [HttpPost]
        public IActionResult DisplayFullPost()
        {
            Comment comments = new Comment
            {
                //get data for blog post display
                userid = (int)HttpContext.Session.GetInt32("UserId"),
                blogpostid = Convert.ToInt32(Request.Form["blogpostid"]),
                content = Request.Form["content"]

            };

            if (comments != null)
            {
                //add the comments to the page
                _dataContext.Comments.Add(comments);
                _dataContext.SaveChanges();
            }
            return RedirectToAction("Blog");
        }


        [HttpGet]
        public IActionResult DisplayFullPost(int id)
        {
            var post = (from p in _dataContext.BlogPosts where p.blogpostid == id select p).FirstOrDefault();

            if (post != null)
            {
                List<CommentViewModel> viewComments = new List<CommentViewModel>();
                var commentList = (from c in _dataContext.Comments where c.blogpostid == id select c).ToList();
                //  viewComments = commentList;

                BlogPostViewModel blogPostView = new BlogPostViewModel
                {
                    BlogPost = post,
                    Comments = viewComments
                };

                foreach (Comment comment in commentList)
                {
                    var user = (from u in _dataContext.Users where u.userid == comment.userid select u).FirstOrDefault();
                    string commentAuthor = user.firstname + " " + user.lastname;

                    CommentViewModel temp = new CommentViewModel
                    {
                        Author = commentAuthor,
                        Comment = comment
                    };

                    string getcomment = temp.Comment.content.ToLower();
                    string[] words = getcomment.Split(' ');

                    var badwords = (from w in _dataContext.BadWords select w).ToList();

                    for (int i = 0; i < words.Count(); i++)
                    {
                        //now search the word in the database
                        foreach (var badw in badwords)
                        {
                            if (badw.word.ToLower().Equals(words[i].ToLower()))
                            {
                                words[i] = "******";
                            }
                        }
                    }

                    temp.Comment.content = ConvertStringArrayToString(words);
                    if (temp != null)
                    {
                        blogPostView.Comments.Add(temp);
                    }
                }

              //  IQueryable<Photo> IPhotos = (from c in _dataContext.Photos where c.blogpostid == id select c);

                // Photo[] photos = IPhotos.ToArray<Photo>();
              //  blogPostView.Photos = IPhotos.ToList();

                blogPostView.User = (from user in _dataContext.Users where user.userid == post.userid select user).FirstOrDefault();
                return View(blogPostView);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult DeleteBlogPost(int id)

        {
            _dataContext.Comments.RemoveRange(from c in _dataContext.Comments where c.blogpostid == id select c);
            _dataContext.SaveChanges();

            var deleteBlogs = (from u in _dataContext.BlogPosts where u.blogpostid == id select u).FirstOrDefault();

            _dataContext.BlogPosts.Remove(deleteBlogs);
            _dataContext.Entry(deleteBlogs).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _dataContext.Photos.RemoveRange(from c in _dataContext.Photos where c.photoid == id select c);
            _dataContext.SaveChanges();

            return RedirectToAction("Blog");
        }

        public IActionResult AddBadWordToDatabase()
        {
            BadWord badWordToAdd = new BadWord
            {
                word = HttpContext.Request.Form["badword"]
            };

            if (badWordToAdd != null)
            {

                _dataContext.BadWords.Add(badWordToAdd);
                _dataContext.SaveChanges();
            }
            return RedirectToAction("ViewBadWords");
        }

        public IActionResult DeleteBadWord(int id)
        {
            var wordToDelete = (from c in _dataContext.BadWords where c.badwordid == id select c).FirstOrDefault();
            _dataContext.BadWords.Remove(wordToDelete);
            _dataContext.Entry(wordToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _dataContext.SaveChanges();
            return RedirectToAction("ViewBadWords");
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadImage(ICollection<IFormFile> files)
        //{
        //    var blogId = HttpContext.Session.GetInt32("editBlogId");
        //    // get your storage accounts connection string
        //    var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cst8359lab5assignment2;AccountKey=yYQYWs3Q24u1okz8ro22XGyOrJj5/6jQmQlL1MdidhnQzkHiOutkj7MmV+4kNYstw1QOG2U0hEciREqor9t6Cg==;EndpointSuffix=core.windows.net");

        //    // create an instance of the blob client
        //    var blobClient = storageAccount.CreateCloudBlobClient();

        //    // create a container to hold your blob (binary large object.. or something like that)
        //    // naming conventions for the curious https://msdn.microsoft.com/en-us/library/dd135715.aspx
        //    var container = blobClient.GetContainerReference("frenckphotostorage");
        //    await container.CreateIfNotExistsAsync();

        //    // set the permissions of the container to 'blob' to make them public
        //    var permissions = new BlobContainerPermissions();
        //    permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
        //    await container.SetPermissionsAsync(permissions);

        //    // for each file that may have been sent to the server from the client
        //    foreach (var file in files)
        //    {
        //        try
        //        {
        //            // create the blob to hold the data
        //            var blockBlob = container.GetBlockBlobReference(file.FileName);
        //            if (await blockBlob.ExistsAsync())
        //                await blockBlob.DeleteAsync();

        //            using (var memoryStream = new MemoryStream())
        //            {
        //                // copy the file data into memory
        //                await file.CopyToAsync(memoryStream);

        //                // navigate back to the beginning of the memory stream
        //                memoryStream.Position = 0;

        //                // send the file to the cloud
        //                await blockBlob.UploadFromStreamAsync(memoryStream);
        //            }

        //            // add the photo to the database if it uploaded successfully
        //            var photo = new Photo();
        //            photo.url = blockBlob.Uri.AbsoluteUri;
        //            photo.filename = file.FileName;
        //            photo.blogpostid = (int)blogId;

        //            System.Diagnostics.Debug.WriteLine("SomeText");
        //            System.Diagnostics.Debug.WriteLine(photo.url);

        //            if (photo != null)
        //            {
        //                _dataContext.Photos.Add(photo);
        //                _dataContext.SaveChanges();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            e.ToString();
        //        }
        //    }

        //    int id = Convert.ToInt32(Request.Form["editBlogId"]);

        //    return RedirectToAction("Index");
        //}



        [HttpGet]// GET: /<controller>/
        public IActionResult EditProfile(int id)
        {

            HttpContext.Session.SetInt32("editProfile", id);
            var editProfile = (from b in _dataContext.Users where b.userid == id select b).FirstOrDefault();
            return View(editProfile);

        }

        [HttpPost]// GET: /<controller>/
        public IActionResult EditProfile(User user)
        {

            int id = Convert.ToInt32(Request.Form["userid"]);
            // var postUpdate = (from m in _dataContext.BlogPosts where m.BlogPostId == id select m).FirstOrDefault();
            User userToUpdate = new User();
            userToUpdate = (from u in _dataContext.Users where u.userid == id select u).FirstOrDefault();

            userToUpdate.firstname = user.firstname;
            userToUpdate.lastname = user.lastname;
            userToUpdate.emailaddress = user.emailaddress;
            userToUpdate.password = user.password;
            userToUpdate.dateofbirth = user.dateofbirth;
            userToUpdate.address = user.address;
            userToUpdate.city = user.city;
            userToUpdate.country = user.country;
            userToUpdate.postalcode = user.postalcode;
            userToUpdate.roleid = user.roleid;


            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ViewBadWords()
        {
            var view = HttpContext.Session.GetString("UserId");
            var badWords = (from badword in _dataContext.BadWords select badword);

            return View(badWords);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }


[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // [Route("Home/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
