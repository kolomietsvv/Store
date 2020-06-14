using BLL;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
	public class OrderController : Controller
	{
		IEntityService<Order, long> orederService;
		IUserService userService;

		public OrderController(IEntityService<Order, long> orederService, IUserService userService)
		{
			this.orederService = orederService;
			this.userService = userService;
		}

		[HttpPost]
		public IActionResult Create(OrderViewModel orderVM)
		{
			var user = userService.GetUser(orderVM.User) ?? userService.Create(orderVM.User);
			var order = new Order
			{
				Items = orderVM.Items.Select(item => new OrderItem
				{
					Count = item.Count,
					Id = item.Id
				}).ToList(),
				User = user,
			};
			var createdOrder = orederService.Create(order);
			return RedirectToAction("GetAll", "Catalogue");
		}

		[HttpGet]
		public IActionResult GetAll(long? limit, long? offset)
		{
			limit ??= long.MaxValue;
			offset ??= 0;
			var result = orederService.GetAll(limit.Value, offset.Value);
			return View("OrdersList", result);
		}
	}
}
