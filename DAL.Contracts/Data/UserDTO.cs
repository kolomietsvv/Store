using Data;

namespace DAL.Contracts.Data
{
	public class UserDTO : Entity<long>
	{
		public string Login { get; set; }

		public byte[] PasswordHash { get; set; }
	}
}
