using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Models
{
    public interface IBlogRepository : IDisposable
    {
        Task<IEnumerable<BlogPost>> GetPosts();
        Task <BlogPost> GetPostByID(int userid);
        Task Add(BlogPost user);
        Task Delete(int userid);
        void UpdatePost(BlogPost student);
        Task Save();
    }
}
