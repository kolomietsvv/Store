using System.Collections.Generic;

namespace Data
{
	public class Order
	{
		public User User { get; set; }

		public List<Item> Items { get; set; }
	}
}
