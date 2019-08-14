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

        public async Task <IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task <IEnumerable<User>> GetByID()
        {
            return await context.Users.ToListAsync();
        }

        public User GetUserByID(int id)
        {
            //return context.Users.FirstOrDefault(x => x.userid == id);
            return context.Users.Find(id);
        }

        public async Task Add(User student)
        {
            await context.Users.AddAsync(student);
        }

        public async Task Delete(int studentID)
        {
            User student = await context.Users.FindAsync(studentID);
            context.Users.Remove(student);
        }

        public void UpdateUser(User student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
