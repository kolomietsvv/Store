using DAL.Contracts;
using Data;

namespace BLL
{
	public abstract class EntityService<TEntity, TId>
		where TEntity : Entity<TId>
	{
		protected IEntityDAO<TEntity, TId> entityDAO;

		public EntityService(IEntityDAO<TEntity, TId> entityDAO)
		{
			this.entityDAO = entityDAO;
		}
	}
}
