using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace profile.Models
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private readonly Storecontext _context;
        //internal DbSet<BlogPost>  _dbSet;


        public BlogRepository(Storecontext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetPosts()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task <BlogPost> GetPostByID(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task Add(BlogPost student)
        {
            _context.Entry(student).State = EntityState.Added;
            await _context.BlogPosts.AddAsync(student);
        }

        public async Task Delete(int studentID)
        {
            BlogPost student = await _context.BlogPosts.FindAsync(studentID);
            _context.BlogPosts.Remove(student);
            _context.Entry(student).State = EntityState.Deleted;

        }

        public void UpdatePost(BlogPost user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
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
