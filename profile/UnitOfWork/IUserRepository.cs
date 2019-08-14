using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace profile.Models
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable <User>> GetUsers();
        User GetUserByID(int userid);
        Task Add(User user);
        Task Delete(int userid);
        void UpdateUser(User student);
        Task Save();

    }
}

