using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Models
{
    public interface IBlogRepository : IDisposable
    {
        IEnumerable<BlogPost> GetPosts();
        BlogPost GetPostByID(int userid);
        void Add(BlogPost user);
        void Delete(int userid);
        void UpdatePost(BlogPost student);
        void Save();
    }
}
