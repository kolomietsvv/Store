using DAL.Contracts;
using DAL.MSSQL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
	public static class DIConfigurator
	{
		public static void ConfigureServices(IServiceCollection services, string connectionString)
		{
			services.AddSingleton<IUserDAO>(new UserDAO(connectionString));
			services.AddSingleton<IUserService, UserService>();
		}
	}
}
