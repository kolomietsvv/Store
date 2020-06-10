using DAL.Contracts;
using Data;
using System.Collections.Generic;

namespace BLL
{
	public class CatalogueService : EntityService<Item, long>, ICatalogueService
	{
		private readonly ICatalogueDAO catalogueDAO;

		public CatalogueService(ICatalogueDAO catalogueDAO) : base(catalogueDAO)
		{
			this.catalogueDAO = entityDAO as ICatalogueDAO;
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

		public List<Item> GetByIds(IEnumerable<long> ids)
		{
			return catalogueDAO.GetByIds(ids);
		}
	}
}
