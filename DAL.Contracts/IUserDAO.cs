using DAL.Contracts.Data;

namespace DAL.Contracts
{
	public interface IUserDAO : IEntityDAO<UserDTO, long>
	{
		UserDTO GetUser(UserDTO user);
	}
}
