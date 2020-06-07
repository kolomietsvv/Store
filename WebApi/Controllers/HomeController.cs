using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using System.Diagnostics;
using System.Threading.Tasks;

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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SignIn(User user)
		{
			await _signInManager.SignInAsync(user, isPersistent: false);
			return Redirect("/");
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View("Login");
		}

		[HttpGet]
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
