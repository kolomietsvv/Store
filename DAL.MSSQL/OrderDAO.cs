using DAL.Contracts;
using Data;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.MSSQL
{
	public class OrderDAO : EntityDAO<Order>, IEntityDAO<Order, long>
	{
		public OrderDAO(string connectionString) : base(connectionString)
		{
		}

		public Order Create(Order order)
		{
			return ExecuteReaderGrouping("CreateOrder", parameters =>
			{
				var sqlParam = parameters.AddWithValue("@items", new OrderDataCollection(order));
				sqlParam.SqlDbType = SqlDbType.Structured;
			},
			reader =>
				new OrderItem
				{
					Id = (long)reader["orderNumber"],
					UserId = (long)reader["userId"],
					ItemId = (long)reader["itemId"],
					Count = (long)reader["count"]
				},
			item => item.UserId,
			group => new Order
			{
				UserId = group.Key,
				Items = group.Select(g => new Data.OrderItem { Id = g.ItemId, Count = g.Count }).ToList()
			});
		}

		public Order Delete(long entity)
		{
			throw new System.NotImplementedException();
		}

		public List<Order> GetAll(long limit, long offset)
		{
			throw new System.NotImplementedException();
		}

		public Order GetById(long id)
		{
			throw new System.NotImplementedException();
		}

		public Order Update(Order entity)
		{
			throw new System.NotImplementedException();
		}

		protected override Order ReadEntity(SqlDataReader reader)
		{
			return new Order { };
		}

		private class OrderItem
		{
			public long Id { get; set; }

			public long UserId { get; set; }

			public long ItemId { get; set; }

			public long Count { get; set; }
		}

		private class OrderDataCollection : Order, IEnumerable<SqlDataRecord>
		{
			public OrderDataCollection(Order order)
			{
				UserId = order.UserId;
				Items = order.Items;
			}

			public IEnumerator GetEnumerator()
			{
				return ((IEnumerable<SqlDataRecord>)this).GetEnumerator();
			}

			IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
			{
				SqlDataRecord ret = new SqlDataRecord(
					new SqlMetaData("userId", SqlDbType.BigInt),
					new SqlMetaData("itemId", SqlDbType.BigInt),
					new SqlMetaData("count", SqlDbType.BigInt)
					);

				foreach (var item in Items)
				{
					ret.SetInt64(0, UserId.Value);
					ret.SetInt64(1, item.Id);
					ret.SetInt64(2, item.Count);
					yield return ret;
				}
			}
		}
	}
}
