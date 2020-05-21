using BLL;
using Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Services
{
	public class UserStore : IUserStore<User>
	{
		IUserService userService;

		public UserStore(IUserService userService)
		{
			this.userService = userService;
		}

		public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}

		public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				userService.Delete(user.Id);
				return IdentityResult.Success;
			});
		}

		public void Dispose()
		{
		}

		public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			return Task.Run(() => userService.GetById(long.Parse(userId)));
		}

		public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => userService.GetUser(user).Login);
		}

		public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => userService.GetUser(user).Id.ToString());
		}

		public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => userService.GetUser(user).Login);
		}

		public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
