using Data;
using System.Collections.Generic;

namespace WebApi.Models
{
	public class OrderViewModel
	{
		public List<OrderItemViewModel> Items { get; set; }

		public User User { get; set; }
	}
}
