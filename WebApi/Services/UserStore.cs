﻿using Data;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Services
{
	public class UserStore : IUserStore<User>
	{
		public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}

		public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}

		public void Dispose()
		{
		}

		public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			return Task.Run(() => new User() { Login = "MockUser" });
		}

		public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			return Task.Run(() => new User() { Login = "MockUser" });
		}

		public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => "MockUser");
		}

		public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => "MockUser");
		}

		public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => "MockUser");
		}

		public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
		{
			return Task.Run(() => "MockUser");
		}

		public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
		{
			return Task.Run(() => "MockUser");
		}

		public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}
	}
}
