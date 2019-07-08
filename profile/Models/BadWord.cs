using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System;



namespace profile.Models
{
    [Table("badwords")]
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
