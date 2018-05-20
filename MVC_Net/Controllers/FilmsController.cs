using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Net.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_Net.Controllers
{
    public class FilmsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            SakilaContext context = HttpContext.RequestServices.GetService(typeof(MVC_Net.Models.SakilaContext)) as SakilaContext;

            return View(Constants.Views.Films, context.GetAllFilms());
        }
    }
}
