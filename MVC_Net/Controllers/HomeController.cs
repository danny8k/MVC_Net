using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using MVC_Net.Models;

namespace MVC_Net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult RestTest()
		{
			var model = new RestModel();

			var requestUrl = new Uri("http://powersports.honda.com/jsonAPI.ashx?f=segments");

			var client = new WebClient();
			var response = client.DownloadString(requestUrl.ToString());

			var hondaSegments = JsonConvert.DeserializeObject<HondaApiSegments>(response);

			model.RestResponse = response;
			model.HondaSegments = hondaSegments;
            

			return View("~/Views/Home/RestTest.cshtml", model);
		}
    }
}
