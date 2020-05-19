using Data;

namespace DAL.Contracts
{
	public interface IUserDAO : IEntityDAO<User, long>
	{
		User GetUser(User user);
	}
}
