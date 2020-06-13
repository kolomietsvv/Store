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
			var userId = userService.GetUser(orderVM.User)?.Id ?? userService.Create(orderVM.User).Id;
			var order = new Order
			{
				Items = orderVM.Items.Select(item => new OrderItem
				{
					Count = item.Count,
					Id = item.Id
				}).ToList(),
				UserId = userId
			};
			var createdOrder = orederService.Create(order);
			return RedirectToAction("GetAll", "Catalogue");
		}
	}
}
