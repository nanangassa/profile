using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using profile.Models;

namespace profile.Models
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private Storecontext context;

        public UserRepository(Storecontext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void Add(User student)
        {
            context.Users.Add(student);
        }

        public void Delete(int studentID)
        {
            User student = context.Users.Find(studentID);
            context.Users.Remove(student);
        }

        public void UpdateUser(User student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
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
