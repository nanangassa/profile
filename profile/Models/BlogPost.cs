using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Mvc;

namespace profile.Models
{
    [Table("blogposts")]
    public class BlogPost
    {
        [Key]
        [Required]
        public int blogpostid
        {
            get;
            set;

        }

        [ForeignKey("userid")]
        public int userid { get; set; }

        [Required]
        [StringLength(200)]
        public string title
        {
            get;
            set;

        }

        [Required]
        [StringLength(5000)]
        public string content
        {
            get;
            set;

        }

        [Required]
        [StringLength(1000)]
        public string shortdescription
        {
            get;
            set;
        }


        [DataType(DataType.Date)]
        public DateTime posted
        {
            get;
            set;

        }


        [Required]
        public bool isavailable
        {
            get;
            set;
        }

        public virtual User user { get; set; }

    }
}

