using DAL.Contracts;
using Data;
using System.Collections.Generic;

namespace BLL
{
	public class OrderService : EntityService<Order, long>, IEntityService<Order, long>
	{
		public OrderService(IEntityDAO<Order, long> orderDAO) : base(orderDAO)
		{
		}

		public Order Create(Order entity)
		{
			return entityDAO.Create(entity);
		}

		public Order Delete(long id)
		{
			throw new System.NotImplementedException();
		}

		public List<Order> GetAll(long limit, long offset)
		{
			return entityDAO.GetAll(limit, offset);
		}

		public Order GetById(long id)
		{
			throw new System.NotImplementedException();
		}

		public Order Update(Order entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
