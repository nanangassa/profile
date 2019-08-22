using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Builder;

namespace profile.Models
{

    public class RootObject
    {
        public Status status { get; set; }
        public List<Datum> data { get; set; }
    }

    [Table("crypto")]
    public class Crypto
    {
        [Required]
        [Key]
        public int userid { get; set; }
        public string idtoken { get; set; }

        [Required(ErrorMessage = "Username must be "), StringLength(40), Display(Name = "Username")]
        public string username { get; set; }
        public string password { get; set; }
        //public virtual ICollection<Crypto> portfolio { get; set; }
        // public IAsyncEnumerable<Crypto> watchlist { get; set; }

    }

    [Table("status")]
    public class Status
    {
        [Required]
        [Key]
        public int statusid { get; set; }
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public string error_message { get; set; } //object
        public int elapsed { get; set; }
        public int credit_count { get; set; }
    }

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    [Table("datum")]
    public class Datum
    {
        [Required]
        [Key]
        public int datumid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int num_market_pairs { get; set; }
        public DateTime date_added { get; set; }
        //public List<object> tags { get; set; } list not supp, foreign key
        public double? max_supply { get; set; }
        public double? circulating_supply { get; set; }
        public double? total_supply { get; set; }
        //public Platform platform { get; set; }
        public int cmc_rank { get; set; }
        public DateTime last_updated { get; set; }
        public virtual Quote quote { get; set; }
    }


    [Table("usd")]
    public class Usd
    {
        [Required]
        [Key]
        public int usdid { get; set; }
        public Int64? price { get; set; }
        public Int64? volume_24h { get; set; }
        public Int64? percent_change_1h { get; set; }
        public Int64? percent_change_24h { get; set; }
        public Int64? percent_change_7d { get; set; }
        public Int64? market_cap { get; set; }
        public DateTime last_updated { get; set; }

    }

    [Table("quote")]
    public class Quote
    {
        [Required]
        [Key, ForeignKey("usdid")]
        public int quoteid { get; set; }
        public Usd USD { get; set; }

        //  [ForeignKey("usdid")]
        //  public int usdid { get; set; }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CryptoExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Crypto>();
        }
    }
}
