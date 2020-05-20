using DAL.Contracts;
using Data;
using System.Collections.Generic;

namespace BLL
{
	public class CatalogueService : EntityService<Item, long>, IEntityService<Item, long>
	{
		public CatalogueService(IEntityDAO<Item, long> catalogueDAO) : base(catalogueDAO)
		{
		}

		public Item Create(Item entity)
		{
			return entityDAO.Create(entity);
		}

		public Item Delete(long id)
		{
			return entityDAO.Delete(id);
		}

		public List<Item> GetAll(long limit, long offset)
		{
			return entityDAO.GetAll(limit, offset);
		}

		public Item GetById(long id)
		{
			return entityDAO.GetById(id);
		}

		public Item Update(Item entity)
		{
			return entityDAO.Update(entity);
		}
	}
}
