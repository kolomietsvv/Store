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
			services.AddSingleton<ICatalogueDAO>(new CatalogueDAO(connectionString));
			services.AddSingleton<IEntityDAO<Order, long>>(new OrderDAO(connectionString));
			services.AddSingleton<IEntityService<Order, long>, OrderService>();
			services.AddSingleton<ICatalogueService, CatalogueService>();
			services.AddSingleton<IUserService, UserService>();
		}
	}
}
