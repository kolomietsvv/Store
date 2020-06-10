using BLL;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	public class OrderController : Controller
	{
		IEntityService<Order, long> orederService;

		public OrderController(IEntityService<Order, long> orederService)
		{
			this.orederService = orederService;
		}

		[HttpPost]
		public IActionResult Create(Order order)
		{
			var createdOrder = orederService.Create(order);
			return null;
		}
	}
}
