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
				parameters.AddWithValue("@name", UserDTO.Name);
				parameters.AddWithValue("@email", UserDTO.Email);
				parameters.AddWithValue("@phone", UserDTO.Phone);
			});
		}

		public UserDTO Delete(long id)
		{
			return base.ExecuteReaderSingle("Delete", parameters =>
			{
				parameters.AddWithValue("@id", id);
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
			return base.ExecuteReaderSingle("GetUserById", parameters =>
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
				parameters.AddWithValue("@name", UserDTO.Name);
				parameters.AddWithValue("@email", UserDTO.Email);
				parameters.AddWithValue("@phone", UserDTO.Phone);
			});
		}

		public UserDTO GetUser(UserDTO UserDTO)
		{
			return base.ExecuteReaderSingle("GetUser", parameters =>
			{
				parameters.AddWithValue("@login", UserDTO.Login);
				parameters.AddWithValue("@password", UserDTO.PasswordHash);
				parameters.AddWithValue("@name", UserDTO.Name);
				parameters.AddWithValue("@email", UserDTO.Email);
				parameters.AddWithValue("@phone", UserDTO.Phone);
			});
		}

		protected override UserDTO ReadEntity(SqlDataReader reader)
		{
			return new UserDTO
			{
				Id = (long)reader["id"],
				Login = reader["login"] as string,
				PasswordHash = reader["password"] as byte[],
				Email = reader["email"] as string,
				Name = reader["name"] as string,
				Phone = reader["phone"] as string,
			};
		}
	}
}
