using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Services
{
	public interface IFileService
	{
		public Task<string> UploadFile(IFormFile file);
	}
}
