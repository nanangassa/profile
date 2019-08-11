using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Controllers
{
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private Storecontext _webAPIDataContext;
		public UserController(Storecontext webAPIDataContext)
		{
			_webAPIDataContext = webAPIDataContext;
		}
		[HttpGet]
		public IEnumerable<User> Get() { 
		
			return _webAPIDataContext.Users.AsEnumerable();
		}

		[HttpGet("{id}")]
		public User Get(int id)
		{
			return _webAPIDataContext.Users.FirstOrDefault(x => x.userid == id);
		}

		[HttpPost]
		public void Post([FromBody]User user)
		{
			_webAPIDataContext.Add(user);
			_webAPIDataContext.SaveChanges();
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody]User user)
		{
			var selectedUser = _webAPIDataContext.BlogPosts.FirstOrDefault(x => x.userid == id);
			if (selectedUser != null)
			{
				_webAPIDataContext.Entry(selectedUser).Context.Update(user);
				_webAPIDataContext.SaveChanges();
			}
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var user = _webAPIDataContext.BlogPosts.FirstOrDefault(x => x.userid == id);
			if (user != null)
			{
				_webAPIDataContext.BlogPosts.Remove(user);
				_webAPIDataContext.SaveChanges();
			}
		}
	}

}