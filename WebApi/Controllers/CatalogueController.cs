using BLL;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
	[Authorize]
	public class CatalogueController : Controller
	{
		IEntityService<Item, long> catalogueService;

		public CatalogueController(IEntityService<Item, long> catalogueService)
		{
			this.catalogueService = catalogueService;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult GetAll(long? limit, long? offset)
		{
			limit ??= long.MaxValue;
			offset ??= 0;
			var result = catalogueService.GetAll(limit.Value, offset.Value);
			if (User.Identity.IsAuthenticated)
			{
				return View("AdminList", result);
			}
			return View("List", result);
		}

		[HttpGet]
		[Route("{id:long}")]
		public IActionResult Get(long id)
		{
			var result = catalogueService.GetById(id);
			return View("List", result);
		}

		[HttpPost]
		public IActionResult Create(Item item)
		{
			var result = catalogueService.Create(item);
			return View("List", result);
		}

		[HttpPost]
		public IActionResult Update(Item item)
		{
			var result = catalogueService.Update(item);
			return View("List", result);
		}

		[HttpGet]
		public IActionResult Delete(long id)
		{
			catalogueService.Delete(id);
			return RedirectToAction("GetAll");
		}
	}
}
