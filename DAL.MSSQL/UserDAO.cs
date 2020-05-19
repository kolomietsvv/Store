using DAL.Contracts;
using DAL.Contracts.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.MSSQL
{
	public class UserDAO : EntityDAO<UserDTO>, IUserDAO
	{
		public UserDAO(string connectionString) : base(connectionString)
		{
		}

		public UserDTO Create(UserDTO UserDTO)
		{
			return base.ExecuteReaderSingle("CreateUser", parameters =>
			{
				parameters.AddWithValue("@login", UserDTO.Login);
				parameters.AddWithValue("@password", UserDTO.PasswordHash);
			});
		}

		public UserDTO Delete(UserDTO UserDTO)
		{
			return base.ExecuteReaderSingle("Delete", parameters =>
			{
				parameters.AddWithValue("@id", UserDTO.Id);
			});
		}

		public List<UserDTO> GetAll(long limit, long offset)
		{
			return base.ExecuteReaderCollection("GetUsers", parameters =>
			{
				parameters.AddWithValue("@limit", limit);
				parameters.AddWithValue("@offset", offset);
			});
		}

		public UserDTO GetById(long id)
		{
			return base.ExecuteReaderSingle("GetUsers", parameters =>
			{
				parameters.AddWithValue("@id", id);
			});
		}

		public UserDTO Update(UserDTO UserDTO)
		{
			return base.ExecuteReaderSingle("UpdateUser", parameters =>
			{
				parameters.AddWithValue("@id", UserDTO.Id);
				parameters.AddWithValue("@login", UserDTO.Login);
				parameters.AddWithValue("@password", UserDTO.PasswordHash);
			});
		}

		public UserDTO GetUser(UserDTO UserDTO)
		{
			return base.ExecuteReaderSingle("GetUser", parameters =>
			{
				parameters.AddWithValue("@login", UserDTO.Login);
				parameters.AddWithValue("@password", UserDTO.PasswordHash);
			});
		}

		protected override UserDTO ReadEntity(SqlDataReader reader)
		{
			return new UserDTO
			{
				Id = (long)reader["id"],
				Login = (string)reader["login"],
				PasswordHash = (byte[])reader["password"],
			};
		}
	}
}
