using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
	public class OrderController : Controller
	{
		[HttpPost]
		public IActionResult Create(CatalogueViewModel catalogue)
		{
			return View();
		}
	}
}
