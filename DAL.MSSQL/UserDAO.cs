using Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.MSSQL
{
	public class UserDAO : EntityDAO<User>, IUserDAO
	{
		public UserDAO(string connectionString) : base(connectionString)
		{
		}

		public User Create(User user)
		{
			return base.ExecuteReaderSingle("CreateUser", parameters =>
			{
				parameters.AddWithValue("login", user.Login);
				parameters.AddWithValue("password", user.Password);
			});
		}

		public User Delete(User user)
		{
			return base.ExecuteReaderSingle("Delete", parameters =>
			{
				parameters.AddWithValue("id", user.Id);
			});
		}

		public List<User> GetAll(long limit, long offset)
		{
			return base.ExecuteReaderCollection("GetUsers", parameters =>
			{
				parameters.AddWithValue("limit", limit);
				parameters.AddWithValue("offset", offset);
			});
		}

		public User GetById(long id)
		{
			return base.ExecuteReaderSingle("GetUsers", parameters =>
			{
				parameters.AddWithValue("id", id);
			});
		}

		public User Update(User user)
		{
			return base.ExecuteReaderSingle("UpdateUser", parameters =>
			{
				parameters.AddWithValue("id", user.Id);
				parameters.AddWithValue("login", user.Login);
				parameters.AddWithValue("password", user.Password);
			});
		}

		public User GetUser(User user)
		{
			return base.ExecuteReaderSingle("GetUser", parameters =>
			{
				parameters.AddWithValue("login", user.Login);
				parameters.AddWithValue("password", user.Password);
			});
		}

		protected override User ReadEntity(SqlDataReader reader)
		{
			return new User
			{
				Id = (long)reader["id"],
				Login = (string)reader["login"],
				Password = (string)reader["password"],
			};
		}
	}
}
