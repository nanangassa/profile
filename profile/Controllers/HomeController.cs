using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using profile.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;
using System.Web;

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
        [ValidateAntiForgeryToken]
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


            var existing = (from users in _dataContext.Users where (users.emailaddress == user.password) select users).FirstOrDefault();


            if (existing == null)
            {
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
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
            //   HttpContext.Session.SetInt32("UserId", user.UserId);
            //return View();

            return RedirectToAction("Blog");
        }

        //[HttpPost("AuthenticateUser/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            // HttpContext.Session.SetInt32("editBlogId", id);
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

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
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
                                words[i] = "******BadWord******";
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

            //_dataContext.Photos.RemoveRange(from c in _dataContext.Photos where c.photoid == id select c);
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

            if (editProfile == null)
            {
                // HandleErrorInfo error = new HandleErrorInfo(
                //     new Exception("INFO: You do not have permission to edit these details"));
                return View("Resume");
            }
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
            return RedirectToAction("Resume");
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

        // GET: /<controller>/
        // public async Task<IActionResult> CryptoIndex()
        public ViewResult CryptoIndex()
        {

            string API_KEY = "851c07eb-8f21-4d4d-85b1-584e6715f71e";
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            WebClient client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");


            string test = client.DownloadString(URL.ToString());
            RootObject list = JsonConvert.DeserializeObject<RootObject>(test);

            //  int i = 0;
            //foreach (var item in list.data)
            //{
            //    //  i++;
            //    Datum datum = new Datum
            //    {
            //        quote = new Quote
            //        {
            //            USD = new Usd()
            //        },

                    //    name = item.name,
                    //    circulating_supply = item.circulating_supply,
                    //    cmc_rank = item.cmc_rank,
                    //    date_added = item.date_added,
                    //    id = item.id,
                    //    slug = item.slug,
                    //    symbol = item.symbol,
                    //    total_supply = item.total_supply,
                    //    last_updated = item.last_updated,
                    //    max_supply = item.max_supply,
                    //    num_market_pairs = item.num_market_pairs
                    //};

                    //datum.quote.USD.price = item.quote.USD.price;
                    //await _dataContext.Datum.AddAsync(item);
                    //await _dataContext.SaveChangesAsync();

                    // if (i > 10)
                    //      break;
                    //  Console.WriteLine("{0} {1} {2} {3} {4} {5}\n", item.id, item.name,
                    //       item.symbol, item.slug, item.quote.USD.price, item.quote.USD.percent_change_1h);
                //}



            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
         

            //aboutViewModel.Datum = _dataContext.Datum.Take(10).ToList();//
            // aboutViewModel.Quote = _dataContext.quote.Take(10).ToList();//
            //aboutViewModel.Usd = _dataContext.usd.Take(10).ToList();

            //= new AboutViewModel
            //{
            //    Datum = _dataContext.Datum.ToList(),
            //    Usd = _dataContext.usd.ToList()
            //};


            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        data = data.OrderByDescending(s => s.volume_24h);
            //        break;
            //    case "Date":
            //        data = data.OrderBy(s => s.percent_change_1h);
            //        break;
            //    case "date_desc":
            //        data = data.OrderByDescending(s => s.percent_change_1h);
            //        break;
            //    default:
            //        data = data.OrderBy(s => s.volume_24h);
            //        break;
            //}

            //return View(list.data.ToAsyncEnumerable());
            return View(list);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // [Route("Home/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
