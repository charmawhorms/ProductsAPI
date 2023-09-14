using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductClientInterface.Models;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace ProductClientInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "https://localhost:7023/products";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            //DataTable dt = new DataTable();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseURL);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage getData = await client.GetAsync(baseURL);

            //    if (getData.IsSuccessStatusCode)
            //    {
            //        string results = getData.Content.ReadAsStringAsync().Result;
            //        dt = JsonConvert.DeserializeObject<DataTable>(results);
            //    }
            //    else
            //    {

            //    }
            //}
            //return View();

            //var products = await _db.Find();
            return View();
            
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