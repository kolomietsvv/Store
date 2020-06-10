using System.Collections.Generic;

namespace Data
{
	public class Order : Entity<long>
	{
		public long? UserId { get; set; }

		public List<OrderItem> Items { get; set; }
	}
}
