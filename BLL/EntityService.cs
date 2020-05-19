using Data;

namespace BLL
{
	public interface IEntityService<TEntity, TId>
		where TEntity : Entity<TId>
	{
		TEntity Create(TEntity entity);

		TEntity Update(TEntity entity);

		TEntity Delete(TEntity entity);

		TEntity GetById(TId id);

		TEntity GetAll(long limit, long offset);
	}
}
