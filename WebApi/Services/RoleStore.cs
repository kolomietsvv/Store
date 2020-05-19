using Data;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Services
{
	public class RoleStore : IRoleStore<Role>
	{
		public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}

		public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}

		public void Dispose()
		{
		}

		public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			return Task.Run(() => new Role { Name = "Admin" });
		}

		public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			return Task.Run(() => new Role { Name = "Admin" });
		}

		public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => "Admin");
		}

		public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => role.Id.ToString());
		}

		public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => role.Name);
		}

		public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
		{
			return Task.Run(() => role.Name = normalizedName);
		}

		public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
		{
			return Task.Run(() => role.Name = roleName);
		}

		public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
		{
			return Task.Run(() => IdentityResult.Success);
		}
	}
}
