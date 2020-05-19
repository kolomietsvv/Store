using Data;
using System.Collections.Generic;

namespace DAL.MSSQL
{
	public interface IEntityDAO<TEntity, TId>
		where TEntity : Entity<TId>
	{
		TEntity Create(TEntity entity);

		TEntity Update(TEntity entity);

		TEntity Delete(TEntity entity);

		TEntity GetById(TId id);

		List<TEntity> GetAll(long limit, long offset);
	}
}
