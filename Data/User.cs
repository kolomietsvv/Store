namespace Data
{
	public class User : Entity<long>
	{
		public string Login { get; set; }

		public string Password { get; set; }

		public Role Role { get; set; }
	}
}
