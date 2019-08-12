using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myprofile.Controllers
{
	[Route("api/[UserController]")]
	public class UserController : Controller
	{
		private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpGet]
        [Route("api/Users/Index")]
        public IEnumerable<User> Index()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        [HttpGet("{id}")]
		public User Get(int id)
		{
            return _unitOfWork.UserRepository.GetByID(id);//.FirstOrDefault(x => x.userid == id);
		}

		[HttpPost]
		public User Post([FromBody]User user)
		{
            return _unitOfWork.UserRepository.Add(user);

        }

        [HttpPut("{id}")]
        public void Put([FromBody]User user)
        {
           _unitOfWork.UserRepository.Update(user);
        }

        [HttpDelete("{id}")]
		public void Delete(int id)
		{
           _unitOfWork.UserRepository.Delete(id);

        }
    }

}