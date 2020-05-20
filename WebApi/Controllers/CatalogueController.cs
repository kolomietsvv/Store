using BLL;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
	public class CatalogueController : Controller
	{
		IEntityService<Item, long> catalogueService;

		public CatalogueController(IEntityService<Item, long> catalogueService)
		{
			this.catalogueService = catalogueService;
		}

		[HttpGet]
		public IActionResult GetAll(long? limit, long? offset)
		{
			limit ??= long.MaxValue;
			offset ??= 0;
			var result = catalogueService.GetAll(limit.Value, offset.Value);
			return View("List", result);
		}
	}
}
