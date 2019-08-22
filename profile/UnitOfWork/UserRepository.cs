using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace profile.Models
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private Storecontext context;

        public UserRepository(Storecontext context)
        {
            this.context = context;
        }

         async Task<IEnumerable<User>> IUserRepository.GetUsers()
        {
            return await context.Users.ToListAsync();
        }

         async Task<User> IUserRepository.GetUserByID(long id)
        {
            return await context.Users.FindAsync(id);
        }

         async Task <User> IUserRepository.Add(User user)
        {
            await context.Users.AddAsync(user);
            return user;
        }

        async Task IUserRepository.Delete(long userid)
        {
            User student = await context.Users.FindAsync(userid);
            context.Users.Remove(student);
        }

        void IUserRepository.UpdateUser(User student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

         async Task IUserRepository.Save()
        {
             await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

         void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
