using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreMVCWithData.Models;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMVCWithData.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			string userName = Request.Cookies["UserName"];
			return View("Index", userName);
		}

		[HttpPost()]
		public IActionResult Index(IFormCollection form){
			string userName = form["userName"].ToString();
			var opts = new CookieOptions();
			opts.Expires = DateTime.Now.AddMinutes(10);
			Response.Cookies.Append("UserName", userName, opts);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult RemoveCookie() {
			Response.Cookies.Delete("UserName");
			return View("Index");
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
