using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Net.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_Net.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Db4freeContext context = HttpContext.RequestServices.GetService(typeof(MVC_Net.Models.Db4freeContext)) as Db4freeContext;

            return View(Constants.Views.Users, context.GetAllUsers());
        }
    }
}
