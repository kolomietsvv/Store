using DAL.MSSQL;
using Data;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
	public class UserService : EntityService<User, long>, IUserService
	{
		private SHA256 sha256;

		public UserService(IUserDAO userDao) : base(userDao)
		{
			sha256 = SHA256.Create();
		}

		public User Create(User user)
		{
			user.Password = Encoding.Unicode.GetString(sha256.ComputeHash(Encoding.Unicode.GetBytes(user.Password)));
			return entityDAO.Create(user);
		}

		public User Delete(User user)
		{
			throw new NotImplementedException();
		}

		public User GetAll(long limit, long offset)
		{
			throw new NotImplementedException();
		}

		public User GetById(long id)
		{
			return entityDAO.GetById(id);
		}

		public User GetUser(User user)
		{
			return ((IUserDAO)entityDAO).GetUser(user);
		}

		public User Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
