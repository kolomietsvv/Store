using Data;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.MSSQL
{
	public class OrderDAO : EntityDAO<Order>
	{
		public OrderDAO(string connectionString) : base(connectionString)
		{
		}

		public Order Create(Order order)
		{
			return ExecuteReaderGrouping("CreateOrder", parameters =>
			{
				var sqlParam = parameters.AddWithValue("@items", order.User.Id);
				sqlParam.SqlDbType = SqlDbType.Structured;
			},
			reader =>
				new OrderItem
				{
					Id = (long)reader["id"],
					UserId = (long)reader["userId"],
					ItemId = (long)reader["itemId"],
				},
			item => item.UserId,
			group => new Order
			{
				User = new User
				{
					Id = group.Key,
				},
				Items = group.Select(g => new Item { Id = g.ItemId }).ToList()
			});
		}

		public void Update() { }

		public void Delete() { }

		public void Get() { }

		public void GetList() { }

		protected override Order ReadEntity(SqlDataReader reader)
		{
			return new Order { };
		}

		private class OrderItem
		{
			public long Id { get; set; }

			public long UserId { get; set; }

			public long ItemId { get; set; }
		}
	}
}
