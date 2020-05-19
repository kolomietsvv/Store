namespace Data
{
	public class Item : Entity<long>
	{
		public string Name { get; set; }

		public string ImgUrl { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }
	}
}
