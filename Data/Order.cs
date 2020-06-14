using System.Collections.Generic;

namespace Data
{
	public class Order : Entity<long>
	{
		public User User { get; set; }

		public List<OrderItem> Items { get; set; }
	}
}
