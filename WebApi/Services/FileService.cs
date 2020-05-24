using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebApi.Services
{
	public class FileService : IFileService
	{
		private string wwwroot = "wwwroot";
		private string imgPath = "/img";
		private string indexPath;
		private int maxIndex;

		public FileService()
		{
			indexPath = string.Format("{0}{1}{2}", wwwroot, imgPath, "/index");
			maxIndex = int.Parse(File.ReadAllText(indexPath));
		}

		public async Task<string> UploadFile(IFormFile file)
		{
			if (file is null)
			{
				return null;
			}

			maxIndex++;
			var fileUrl = string.Format("{0}/{1}{2}", imgPath, maxIndex.ToString(), Path.GetExtension(file.FileName));
			var filePath = string.Format("{0}/{1}", wwwroot, fileUrl);
			using (var fileStream = File.Create(filePath))
			{
				await file.CopyToAsync(fileStream);
			};
			File.WriteAllText(indexPath, maxIndex.ToString());
			return fileUrl;
		}
	}
}
