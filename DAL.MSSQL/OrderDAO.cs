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
			GetOrder, item => item.User.Id, OrdersByUser);
		}

		public Order Delete(long entity)
		{
			throw new System.NotImplementedException();
		}

		public List<Order> GetAll(long limit, long offset)
		{
			return ExecuteReaderCollectionGrouping("GetOrders", parameters =>
			{
				parameters.AddWithValue("@limit", limit);
				parameters.AddWithValue("@offset", offset);
			},
			GetOrder, item => item.Id, OrdersById);
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
			throw new System.NotImplementedException();
		}

		private Order GetOrder(SqlDataReader reader)
		{
			return new Order
			{
				Id = (long)reader["orderNumber"],
				User = new User
				{
					Id = (long)reader["userId"],
					Email = (string)reader["userEmail"],
					Name = (string)reader["userName"],
					Phone = (string)reader["userPhone"],
				},
				Items = new List<OrderItem>
				{
					new OrderItem
					{
						Id = (long)reader["itemId"],
						Name = (string)reader["itemName"],
						ImgUrl = (string)reader["itemImgUrl"],
						Price = (decimal)reader["itemPrice"],
						Count = (long)reader["itemCount"],
					}
				},
			};
		}

		private Order OrdersByUser(IGrouping<long, Order> group)
		{
			return new Order
			{
				Id = group.FirstOrDefault()?.Id ?? default,
				User = group.FirstOrDefault().User,
				Items = group.Select(g => g.Items.First()).ToList()
			};
		}

		private Order OrdersById(IGrouping<long, Order> group)
		{
			return new Order
			{
				Id = group.Key,
				User = group.FirstOrDefault().User,
				Items = group.Select(g => g.Items.First()).ToList()
			};
		}

		private class OrderDataCollection : Order, IEnumerable<SqlDataRecord>
		{
			public OrderDataCollection(Order order)
			{
				User = order.User;
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
					ret.SetInt64(0, User.Id);
					ret.SetInt64(1, item.Id);
					ret.SetInt64(2, item.Count);
					yield return ret;
				}
			}
		}
	}
}
