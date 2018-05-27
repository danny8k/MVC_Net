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

		[HttpGet]
		public IActionResult AddUser()
        {
			return View(Constants.Views.AddUser);
        }

		[HttpPost]
		public IActionResult AddUser(User newUser)
        {
            Db4freeContext context = HttpContext.RequestServices.GetService(typeof(MVC_Net.Models.Db4freeContext)) as Db4freeContext;

            context.AddUser(newUser);

            return Redirect("http://www." + newUser.fname + ".com");

        }

        public IActionResult DeleteUser(int userId)
        {
            Db4freeContext context = HttpContext.RequestServices.GetService(typeof(MVC_Net.Models.Db4freeContext)) as Db4freeContext;

            context.DeleteUser(userId);

            return Redirect("http://www.google.com/" + userId.ToString());
        }
    }
}
