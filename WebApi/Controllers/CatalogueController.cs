using BLL;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace Store.Controllers
{
	[Authorize]
	public class CatalogueController : Controller
	{
		IEntityService<Item, long> catalogueService;
		IFileService fileService;

		public CatalogueController(IEntityService<Item, long> catalogueService, IFileService fileService)
		{
			this.catalogueService = catalogueService;
			this.fileService = fileService;
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
				return View("AdminList", result.Select(i => new ItemViewModel(i)).ToList());
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
		public async Task<IActionResult> Update(ItemViewModel item)
		{
			var imgUrl = await fileService.UploadFile(item.UploadedImage);
			item.ImgUrl = imgUrl ?? item.ImgUrl;
			catalogueService.Update(item);
			return RedirectToAction("GetAll");
		}

		[HttpGet]
		public IActionResult Delete(long id)
		{
			catalogueService.Delete(id);
			return RedirectToAction("GetAll");
		}
	}
}
