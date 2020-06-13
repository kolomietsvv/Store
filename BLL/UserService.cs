using DAL.Contracts;
using DAL.Contracts.Data;
using Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
	public class UserService : IUserService
	{
		private SHA256 sha256;
		protected IUserDAO userDAO;

		public UserService(IUserDAO userDAO)
		{
			sha256 = SHA256.Create();
			this.userDAO = userDAO;
		}

		public User Create(User user)
		{
			var userDTO = GetUserDTO(user);
			userDTO = userDAO.Create(userDTO);
			return GetUser(userDTO);
		}

		public User Delete(long id)
		{
			throw new NotImplementedException();
		}

		public List<User> GetAll(long limit, long offset)
		{
			throw new NotImplementedException();
		}

		public User GetById(long id)
		{
			return GetUser(userDAO.GetById(id));
		}

		public User GetUser(User user)
		{
			UserDTO userDTO;
			if (user.Id != default)
			{
				userDTO = userDAO.GetById(user.Id);
				return GetUser(userDTO);
			}
			userDTO = GetUserDTO(user);
			userDTO = userDAO.GetUser(userDTO);
			return GetUser(userDTO);
		}

		public User Update(User user)
		{
			throw new NotImplementedException();
		}

		private UserDTO GetUserDTO(User user)
		{
			return new UserDTO
			{
				Id = user.Id,
				Login = user.Login,
				PasswordHash = user.Password is null ? null :
					sha256.ComputeHash(Encoding.Unicode.GetBytes(user.Password)),
				Email = user.Email,
				Name = user.Name,
				Phone = user.Phone,
			};
		}

		private User GetUser(UserDTO userDTO)
		{
			if (userDTO is null)
			{
				return null;
			}

			return new User
			{
				Id = userDTO.Id,
				Login = userDTO.Login,
			};
		}
	}
}
