using GarbageCollector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GarbageCollector.Controllers
{
    //HttpClient
    //Google Maps API (both JavaScript + Geolocating)
    //JsonDeserialization
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GeocodingURL()
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address={customer.Address.StreetAddress}+{customer.Address.City}+{customer.Address.State}" + GoogleApiKeys.apiKey);
            //request.Headers.Add("Authorization Basic: ") + secretKey);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            Customer search = parsedString.ToObject<Customer>();
            return View(search);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      

    }
}
            