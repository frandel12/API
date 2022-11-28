using Microsoft.AspNetCore.Mvc;
using m = Parcial2.Models;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Parcial2.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Parcial2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string apiResponse = "";
            Root root = null;
            m.PokemonList results = null;

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=151"))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<m.PokemonList>(apiResponse);
                }
            }
            foreach ( Pokemon pokemon in results.results)
            {
                using (var httpclient = new HttpClient())
                {
                    using (var response = await httpclient.GetAsync(pokemon.url))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<m.PokemonList>(apiResponse);
                    }

                }
            }

            ViewBag.PokemonList = results;
            return View();
        }

        public async Task<IActionResult> Index2()
        {
            return View();
        }
   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new m.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}