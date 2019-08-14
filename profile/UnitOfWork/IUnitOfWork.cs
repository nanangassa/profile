

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Models
{
    public class IUnitOfWork //: Controller
    {
        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<User> blogRepository { get; }


        //private void Save();
    }

}
