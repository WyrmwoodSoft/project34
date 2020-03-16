using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project34.Models;

namespace Project34.Controllers
{
    public class HomeController : Controller
    {
        public HttpClient client = new HttpClient();
        public const string DiscordUrl = @"https://discordapp.com/api/guilds/475384812212060214/widget.json";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("Contact/Discord")]
        public async Task<string> Discord()
        {
            var discordServer = await client.GetAsync(DiscordUrl);
            var response = discordServer.Content.ReadAsStringAsync().Result;

            return response.ToString();
        }

        [HttpGet]
        [Route("Privacy")]
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
