using Data;

namespace BLL
{
	public interface IUserService : IEntityService<User, long>
	{
		User GetUser(User user);
	}
}
