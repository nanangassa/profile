
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using System.Collections.Generic;


namespace profile.ViewModels
{
    public class BlogPostViewModel 
    {
        public List<Models.BlogPost> BlogPosts { get; set; }
        public Models.User User { get; set; }
        public Models.BlogPost BlogPost { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<IndexViewModel> IndexViewModels { get; set; }
        public List<Models.Photo> Photos { get; set; }


    }

    public class CommentViewModel
    {
        public Models.Comment Comment { get; set; }
        public string Author { get; set; }
    }

    public class IndexViewModel
    {
        public Models.User User { get; set; }
        public List<Models.BlogPost> BlogPosts { get; set; }
    }
}