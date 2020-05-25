using System.Collections.Generic;

namespace Data
{
	public class Basket : Entity<long>
	{
		User user { get; set; }
		List<Item> Items { get; set; }
	}
}
