using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using profile.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Controllers
{
    public class CryptoController : Controller
    {

        private static string API_KEY = "851c07eb-8f21-4d4d-85b1-584e6715f71e";
        private Storecontext _dataContext;//= new DatabaseContext();

        // GET: /<controller>/
        public async Task<IActionResult> Index(string sortOrder)
        {

            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            WebClient client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");


            string test = client.DownloadString(URL.ToString());     
            RootObject list = JsonConvert.DeserializeObject<RootObject>(test);

          //  int i = 0;
            foreach (var item in list.data)
            {
              //  i++;
                Datum datum = new Datum
                {
                    quote = new Quote
                    {
                        USD = new Usd()
                    },

                    name = item.name,
                    circulating_supply = item.circulating_supply,
                    cmc_rank = item.cmc_rank,
                    date_added = item.date_added,
                    id = item.id,
                    slug = item.slug,
                    symbol = item.symbol,
                    total_supply = item.total_supply,
                    last_updated = item.last_updated,
                    max_supply = item.max_supply,
                    num_market_pairs = item.num_market_pairs
                };

                datum.quote.USD.price = item.quote.USD.price;
                await _dataContext.Datum.AddAsync(item);
                await _dataContext.SaveChangesAsync();

               // if (i > 10)
              //      break;
                //  Console.WriteLine("{0} {1} {2} {3} {4} {5}\n", item.id, item.name,
                //       item.symbol, item.slug, item.quote.USD.price, item.quote.USD.percent_change_1h);
            }



            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var data = list.data.ToAsyncEnumerable();


            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(s => s.name);//s.quote.USD.volume_24h);
                    break;
                case "Date":
                    data = data.OrderBy(s => s.quote.USD.percent_change_1h);
                    break;
                case "date_desc":
                    data = data.OrderByDescending(s => s.quote.USD.percent_change_1h);
                    break;
                default:
                    data = data.OrderBy(s => s.quote.USD.volume_24h);
                    break;
            }

            return View(data);
            //return View(list);
        }
    }
}
