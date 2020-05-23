using Data;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models
{
	public class ItemViewModel : Item
	{
		public IFormFile UploadedImage { get; set; }

		public ItemViewModel()
		{
		}

		public ItemViewModel(Item item)
		{
			Description = item.Description;
			Id = item.Id;
			ImgUrl = item.ImgUrl;
			Name = item.Name;
			Price = item.Price;
		}
	}
}
