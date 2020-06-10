using Data;

namespace WebApi.Models
{
	public class OrderItemViewModel : Item
	{
		public long Count { get; set; }

		public OrderItemViewModel()
		{ }

		public OrderItemViewModel(Item item, long count)
		{
			Count = count;
			Description = item.Description;
			Id = item.Id;
			ImgUrl = item.ImgUrl;
			Name = item.Name;
			Price = item.Price;
		}
	}
}
