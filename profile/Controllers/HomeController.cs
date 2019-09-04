using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using profile.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Web;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;



namespace profile.Models
{

    //[Route("api/")]
    // [Route("api/Views")]


    // [Route("Home/Controllers/HomeController")]

    public class HomeController : Controller
    {
        private IUserRepository rep;
        private IBlogRepository blog;
        //private readonly HttpClient client = new HttpClient();


        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public HomeController(IUserRepository userRepository, IBlogRepository blogRep)
        {
            rep = userRepository;
            blog = blogRep;
        }

        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return _dataContext.Users;
        //}

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

        //public IActionResult Blog(BlogPostViewModel IndexModel)
        public async Task <IActionResult> Blog(BlogPostViewModel IndexModel)

        {
            IndexModel.BlogPosts = await _unitOfWork.blogRepository.GetAll();
           // IEnumerable<Datum> data = (from c in list.data select c).ToList();

            try
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId)"));
                if (userId != 0)
                {
                    //    IndexModel.User = _dataContext.Users.Where(s => s.UserId == userId).FirstOrDefault;
                    //where s.UserId.Equals(userId)
                    //select s;
                    IndexModel.User = (from m in await _unitOfWork.UserRepository.GetAll() where m.userid == userId select m).FirstOrDefault();
                    //IndexModel.User = _dataContext.Users.FirstOrDefault(o => o.userid == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Put your error message here.", ex);

            }
            return View(IndexModel);
        }


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


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(User user)
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


            //var existing = (from users in _unitOfWork.UserRepository.GetAll() where (users.emailaddress == user.password) select users).FirstOrDefault();
            var existing = (from users in await rep.GetUsers() where (users.emailaddress == user.password) select users).FirstOrDefault();


            if (existing == null)
            {
                await _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Save();
            }

            return RedirectToAction("Login");
        }


        // GET: /<controller>/
                 // [Route("Home/Login")]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]// GET: /<controller>/
        //[Route("Home/Login")]
        public IActionResult LogIn(User user)
        {
            //return View();

            return RedirectToAction("Blog");
        }

        //[HttpPost("AuthenticateUser/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> AuthenticateUser()
        {

            string email = Request.Form["EmailAddress"];
            string pass = Request.Form["Password"];

            var user = (from u in await rep.GetUsers() where (u.emailaddress == email && u.password == pass) select u).FirstOrDefault();
            //var user = (from u in _unitOfWork.UserRepository.GetAll() where (u.emailaddress == email && u.password == pass) select u).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", (int)user.userid);
                HttpContext.Session.SetString("RoleId", user.roleid);
                HttpContext.Session.SetString("FN", user.firstname);
                HttpContext.Session.SetString("LN", user.lastname);
                HttpContext.Session.SetString("Password", user.password);
                return RedirectToAction("Blog");


            }
            return RedirectToAction("Login");
        }

        [HttpGet]

        public async Task <IActionResult> EditBlogPost(int id)
        {
            // HttpContext.Session.SetInt32("editBlogId", id);
            var editPost = (from b in await _unitOfWork.blogRepository.GetAll() where b.blogpostid == id select b).FirstOrDefault();
            return View(editPost);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlogPost(BlogPost posts)
        {

            int id = Convert.ToInt32(Request.Form["blogpostid"]);
            var postUpdate = (from m in await _unitOfWork.blogRepository.GetAll() where m.blogpostid == id select m).FirstOrDefault();
            postUpdate.title = posts.title;
            postUpdate.content = posts.content;
            postUpdate.posted = posts.posted;
            postUpdate.shortdescription = posts.shortdescription;

            //save changes to edits
            await _unitOfWork.blogRepository._context.SaveChangesAsync();
            //_unitOfWork.Save();
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
                    _unitOfWork.blogRepository._context.Add(blogPost);
                    _unitOfWork.Save();
                }
            }
            return RedirectToAction("Blog");
        }

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
                 _unitOfWork.blogRepository._context.Comments.Add(comments);
                _unitOfWork.Save();
            }
            return RedirectToAction("Blog");
        }

        [HttpGet]
        public async Task<IActionResult> DisplayFullPost(int id)
        {

            var post = (from p in await _unitOfWork.blogRepository.GetAll() where p.blogpostid == id select p).FirstOrDefault();
            if (post != null)
            {
                List<CommentViewModel> viewComments = new List<CommentViewModel>();
                var commentList = (from c in _unitOfWork.blogRepository._context.Comments where c.blogpostid == id select c).ToList();

                BlogPostViewModel blogPostView = new BlogPostViewModel
                {
                    BlogPost = post,
                    Comments = viewComments
                };

                foreach (Comment comment in commentList)
                {
                    var user = (from u in await _unitOfWork.UserRepository.GetAll() where u.userid == comment.userid select u).FirstOrDefault();
                    string commentAuthor = user.firstname + " " + user.lastname;

                    CommentViewModel temp = new CommentViewModel
                    {
                        Author = commentAuthor,
                        Comment = comment
                    };

                    string getcomment = temp.Comment.content.ToLower();
                    string[] words = getcomment.Split(' ');

                    var badwords = (from w in _unitOfWork.blogRepository._context.BadWords select w).ToList();

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

                blogPostView.User = (from user in _unitOfWork.blogRepository._context.Users where user.userid == post.userid select user).FirstOrDefault();
                return View(blogPostView);
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult DeleteBlogPost(int id)

        {
            _unitOfWork.blogRepository._context.Comments.RemoveRange(from c in _unitOfWork.blogRepository._context.Comments where c.blogpostid == id select c);
            _unitOfWork.blogRepository._context.SaveChanges();

            var deleteBlogs = (from u in _unitOfWork.blogRepository._context.BlogPosts where u.blogpostid == id select u).FirstOrDefault();

            _unitOfWork.blogRepository._context.BlogPosts.Remove(deleteBlogs);
            _unitOfWork.blogRepository._context.Entry(deleteBlogs).State = EntityState.Deleted;

            //_dataContext.Photos.RemoveRange(from c in _dataContext.Photos where c.photoid == id select c);
            _unitOfWork.Save();

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

                _unitOfWork.blogRepository._context.BadWords.Add(badWordToAdd);
                _unitOfWork.Save();
            }
            return RedirectToAction("ViewBadWords");
        }

        public IActionResult DeleteBadWord(int id)
        {
            var wordToDelete = (from c in _unitOfWork.blogRepository._context.BadWords where c.badwordid == id select c).FirstOrDefault();
            _unitOfWork.blogRepository._context.BadWords.Remove(wordToDelete);
            _unitOfWork.blogRepository._context.Entry(wordToDelete).State = EntityState.Deleted;

            //_unitOfWork.blogRepository._context.SaveChanges();
            _unitOfWork.Save();

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



        public async Task <IActionResult> EditProfile()
        {

            // HttpContext.Session.SetInt32("editProfile", id);
            int id = (int)HttpContext.Session.GetInt32("UserId");

            var editProfile = (from b in await _unitOfWork.UserRepository.GetAll() where b.userid == id select b).FirstOrDefault();
            if (editProfile == null)
            {
                // HandleErrorInfo error = new HandleErrorInfo(
                //     new Exception("INFO: You do not have permission to edit these details"));
                return View("Resume");
            }
            return View(editProfile);

        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(User user)
        {

            long id = Convert.ToInt32(Request.Form["userid"]);
            // var postUpdate = (from m in _dataContext.BlogPosts where m.BlogPostId == id select m).FirstOrDefault();
            User userToUpdate = new User();
            userToUpdate = (from u in await _unitOfWork.UserRepository.GetAll() where u.userid == id select u).FirstOrDefault();

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


            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult ViewBadWords()
        {
            var view = HttpContext.Session.GetString("UserId");
            var badWords = (from badword in _unitOfWork.blogRepository._context.BadWords select badword);

            return View(badWords);
        }


        [HttpGet]
        public IActionResult Chart()
        {
            return View();
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

        
        public ViewResult CryptoIndex(string sortOrder, string currentFilter, string searchString, int? pageNumber)
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

            //ViewData["RankSortParm"] = String.IsNullOrEmpty(sortOrder) ? "rank_desc" : "rank";
            ViewData["RankSortParm"] = sortOrder == "rank" ? "rank_desc" : "rank";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";
            ViewData["24hvolume"] = sortOrder == "24hvolume" ? "24hvolume_desc" : "24hvolume";
            ViewData["1hSortParm"] = sortOrder == "1h" ? "1h_desc" : "1h";
            ViewData["7d%Parm"] = sortOrder == "%7d" ? "%7d_desc" : "%7d";
            ViewData["24h%Parm"] = sortOrder == "%24h" ? "%24h_desc" : "%24h";
            ViewData["MarketCapSortParm"] = sortOrder == "market" ? "market_desc" : "market";
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Datum> data = (from c in list.data select c).ToList() ;

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.name.ToLower().Contains(searchString.ToLower()));

            }

            switch (sortOrder)
            {

                case "price_desc":
                    data = data.OrderByDescending(s => s.quote.USD.price);
                    break;

                case "price":
                    data = data.OrderBy(s => s.quote.USD.price);
                    break;

                case "name_desc":
                    data = data.OrderByDescending(s => s.name);
                    break;

                case "name":
                    data = data.OrderBy(s => s.name);
                    break;

                case "24hvolume_desc":
                    data = data.OrderByDescending(s => s.quote.USD.volume_24h);
                    break;

                case "24hvolume":
                    data = data.OrderBy(s => s.quote.USD.volume_24h);
                    break;

                case "1h":
                    data = data.OrderBy(s => s.quote.USD.percent_change_1h);
                    break;

                case "1h_desc":
                    data = data.OrderByDescending(s => s.quote.USD.percent_change_1h);
                    break;

     
                case "market_desc":
                    data = data.OrderByDescending(s => s.quote.USD.market_cap);
                    break;

                case "market":
                    data = data.OrderBy(s => s.quote.USD.market_cap);
                    break;

                case "%7d":
                    data = data.OrderByDescending(s => s.quote.USD.percent_change_7d);
                    break;

                case "%7d_desc":
                    data = data.OrderBy(s => s.quote.USD.percent_change_7d);
                    break;

                case "%24h":
                    data = data.OrderByDescending(s => s.quote.USD.percent_change_24h);
                    break;

                case "%24h_desc":
                    data = data.OrderBy(s => s.quote.USD.percent_change_24h);
                    break;

                case "rank_desc":
                    data = data.OrderByDescending(s => s.cmc_rank);
                    break;


                default:
                     data = data.OrderBy(s => s.cmc_rank);
                    break;
            }

           // int pageSize = 3;
            //return View(PaginatedList<Datum>.CreateAsync(data.AsQueryable().AsNoTracking(), pageNumber ?? 1, pageSize));
              return View(data);
            // return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // [Route("Home/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
