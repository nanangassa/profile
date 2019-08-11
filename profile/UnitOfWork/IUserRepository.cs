using System;
using System.Collections.Generic;

namespace profile.Models
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userid);
        void Add(User user);
        void Delete(int userid);
        void UpdateUser(User student);
        void Save();

    }
}

