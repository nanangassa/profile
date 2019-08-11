using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using profile.Models;

namespace profile.Models
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private Storecontext _context;

        public BlogRepository(Storecontext context)
        {
            this._context = context;
        }

        public IEnumerable<BlogPost> GetPosts()
        {
            return _context.BlogPosts.ToList();
        }

        public BlogPost GetPostByID(int id)
        {
            return _context.BlogPosts.Find(id);
        }

        public void Add(BlogPost student)
        {
            _context.BlogPosts.Add(student);
        }

        public void Delete(int studentID)
        {
            BlogPost student = _context.BlogPosts.Find(studentID);
            _context.BlogPosts.Remove(student);
        }

        public void UpdatePost(BlogPost student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
