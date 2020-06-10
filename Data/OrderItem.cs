using System.Collections.Generic;

namespace Data
{
	public class OrderItem : Entity<long>
	{
		public long Count { get; set; }
	}
}