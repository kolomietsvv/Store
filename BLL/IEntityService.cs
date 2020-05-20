using Data;
using System.Collections.Generic;

namespace BLL
{
	public interface IEntityService<TEntity, TId>
		where TEntity : Entity<TId>
	{
		TEntity Create(TEntity entity);

		TEntity Update(TEntity entity);

		TEntity Delete(TId id);

		TEntity GetById(TId id);

		List<TEntity> GetAll(long limit, long offset);
	}
}
