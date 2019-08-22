using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace profile.Models
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable <User>> GetUsers();
        Task <User> GetUserByID(long userid);
        Task <User> Add(User user);
        Task Delete(long userid);
        void UpdateUser(User student);
        Task Save();
    }
}

