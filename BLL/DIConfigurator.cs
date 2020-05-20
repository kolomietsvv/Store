using DAL.Contracts;
using DAL.MSSQL;
using Data;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
	public static class DIConfigurator
	{
		public static void ConfigureServices(IServiceCollection services, string connectionString)
		{
			services.AddSingleton<IUserDAO>(new UserDAO(connectionString));
			services.AddSingleton<IEntityDAO<Item, long>>(new CatalogueDAO(connectionString));
			services.AddSingleton<IEntityService<Item, long>, CatalogueService>();
			services.AddSingleton<IUserService, UserService>();
		}
	}
}
