
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace profile.Models
{
    public class Role
    {
        [Required]
		public int roleid
		{
			get;
			set;

		}

		[Required]
		[StringLength(100)]
		public string name
		{
			get;
			set;
		}
	}
}