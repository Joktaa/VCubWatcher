using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VCubWatcher.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VCubWatcher.Controllers
{
    public class HomeController : Controller
    {
        // GET \\

        private static List<Station> getStation(){
            HttpClient client = new HttpClient();
            string url = "https://api.alexandredubois.com/vcub-backend/vcub.php";

            var stringTask = client.GetStringAsync(url);
            var myJsonResponse = stringTask.Result;
            var stations = JsonConvert.DeserializeObject<List<Station>>(myJsonResponse);

            return stations;
        }

        // CODE \\

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stations()
        {
            var stations = getStation();
            stations.Sort((x, y) => string.Compare(x.Name, y.Name));
            return View(stations);
        }

        public IActionResult Carte()
        {
            return View();
        }

        public IActionResult Favoris()
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
