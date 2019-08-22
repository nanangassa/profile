
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace profile.Models
{
    public class Photo
    {
        [Key]
        public int photoid
        {
            get;
            set;
        }

        [ForeignKey("BlogPost")]
        public int blogpostid
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string filename
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string url
        {
            get;
            set;
        }

       // public virtual BlogPost blogpost { get; set; }
    }
}
