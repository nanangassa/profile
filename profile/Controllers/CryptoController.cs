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
using System.Net.Http;
using System.IO;
using System.Text;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace profile.Controllers
{
    public class CryptoController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            // Create the HttpContent for the form to be posted.
            var requestContent = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("text", "This is a block of text"),
            });

            // Get the response.
            HttpResponseMessage response = await client.PostAsync(
                "https://api.blockcypher.com/v1/bcy/test/oap/addrs?token=a94aab1313a9471a97779a8b6facac80",
                requestContent);

            // Get the response content.
            HttpContent responseContent = response.Content;

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                var test1 = await reader.ReadToEndAsync();
                Console.WriteLine(test1);
                var reservation = JsonConvert.DeserializeObject<CreateWallet>(test1);

                //return View(Json(reader.ReadToEndAsync()));
              return View(reservation);
            }            // Pass the data into the View
        }

        //public ViewResult Index()
        //{
        //    return View(Wallet());
        //}

    }
}
