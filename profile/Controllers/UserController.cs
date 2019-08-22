using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using profile.Models;
using profile.UnitOfWork;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myprofile
{
    [Route("api/Users")]
    public class UserController : Controller
	{
		private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpGet]
        [Route("")]
        [Route("api/Users/Index")]
        [ValidateAntiForgeryToken]
        //public async Task<IEnumerable<User>> GetUsers()
        public async Task <IEnumerable<User>> GetAll()
        // public IEnumerable<User> GetUsers()
        //public async IEnumerable<User> Index()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Route("{id:int}")]
        [ValidateAntiForgeryToken]
        public Task <User> Get(int id)
		{
            return _unitOfWork.UserRepository.GetByID(id);//.FirstOrDefault(x => x.userid == id);
		}

		[HttpPost]
        [Route("api/Users/Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<User>> Post([FromBody]User user)
		{
             await _unitOfWork.UserRepository.Add(user);
             _unitOfWork.Save();
            return CreatedAtAction(nameof(user), new { id = user.userid }, user);


        }

        //[HttpPut("{id}")]
        [Route("{id:int}")]
        [ValidateAntiForgeryToken]
        public void Put([FromBody]User user)
        {
           _unitOfWork.UserRepository.Update(user);
        }

        [HttpDelete("{id}")]
        [Route("api/Users/Delete")]
        [ValidateAntiForgeryToken]
        public void Delete(User id)
		{
           _unitOfWork.UserRepository.Delete(id);

        }
    }

}