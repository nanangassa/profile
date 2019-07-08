
using System.ComponentModel.DataAnnotations;


namespace profile.Models
{
    public class BadWord
    {
        [Key]
        public int badwordid
        {
            get;
            set;
        }

        [Required]
        [StringLength(1000)]
        public string word
        {
            get;
            set;
        }
    }
}
