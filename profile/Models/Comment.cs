
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profile.Models
{

    [Table("comments")]
    public class Comment
    {
        [Key]
        public int commentid
        {
            get;
            set;

        }

        public int blogpostid
        {
            get;
            set;

        }

        [ForeignKey("userid")]
        public int userid
        {
            get;
            set;

        }

        [Required]
        [StringLength(1000)]
        public string content
        {
            get;
            set;

        }
    }
}