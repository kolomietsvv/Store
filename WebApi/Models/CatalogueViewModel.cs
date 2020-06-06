using Data;
using System.Collections.Generic;

namespace WebApi.Models
{
	public class CatalogueViewModel
	{
		public List<Item> Items { get; set; }

		public long? UserId { get; set; }

		public List<long> Order { get; set; } = new List<long>();
	}
}
