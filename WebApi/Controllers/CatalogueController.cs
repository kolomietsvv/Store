using BLL;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace Store.Controllers
{
	[Authorize]
	public class CatalogueController : Controller
	{
		ICatalogueService catalogueService;
		IFileService fileService;
		IUserService userService;

		public CatalogueController(ICatalogueService catalogueService,
			IFileService fileService,
			IUserService userService)
		{
			this.catalogueService = catalogueService;
			this.fileService = fileService;
			this.userService = userService;
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
			return View("List", new CatalogueViewModel { Items = result, Order = new Order { } });
		}

		[HttpGet]
		[Route("{id:long}")]
		public IActionResult Get(long id)
		{
			var result = catalogueService.GetById(id);
			return View("List", result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ItemViewModel item)
		{
			var imgUrl = await fileService.UploadFile(item.UploadedImage);
			item.ImgUrl = imgUrl ?? item.ImgUrl;
			catalogueService.Create(item);
			return RedirectToAction("GetAll");
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

		[HttpPost]
		[AllowAnonymous]
		public IActionResult Checkout(Order order)
		{
			if (order?.Items?.Any() != true)
			{
				return RedirectToAction("GetAll");
			}
			var items = catalogueService.GetByIds(order.Items.Select(item => item.Id));
			var user = order.UserId.HasValue ? userService.GetById(order.UserId.Value) : null;
			var orderViewModel = new OrderViewModel()
			{
				Items = items
					.Join(order.Items, i => i.Id, i => i.Id, (item, order) => new OrderItemViewModel(item, order.Count))
					.ToList(),
				User = user
			};
			return View("Order", orderViewModel);
		}
	}
}
