using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Store.Models;

namespace Store.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		SignInManager<User> _signInManager;

		public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager)
		{
			_logger = logger;
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> SignIn()
		{
			await _signInManager.SignInAsync(new User { }, isPersistent: false);
			return Redirect("/");
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/");
		}

		[HttpGet]
		public async Task<IActionResult> SignUp()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/");
		}

		public IActionResult Index()
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
