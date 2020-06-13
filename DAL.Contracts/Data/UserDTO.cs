using Data;

namespace DAL.Contracts.Data
{
	public class UserDTO : Entity<long>
	{
		public string Login { get; set; }

		public byte[] PasswordHash { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }
	}
}
