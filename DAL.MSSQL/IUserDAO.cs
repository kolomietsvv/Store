using Data;

namespace DAL.MSSQL
{
	public interface IUserDAO : IEntityDAO<User, long>
	{
		User GetUser(User user);
	}
}
