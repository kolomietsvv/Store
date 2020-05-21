using DAL.Contracts;
using Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.MSSQL
{
	public class CatalogueDAO : EntityDAO<Item>, IEntityDAO<Item, long>
	{
		public CatalogueDAO(string connectionString) : base(connectionString)
		{
		}

		public Item Create(Item Item)
		{
			return base.ExecuteReaderSingle("CreateCatalogueItem", parameters =>
			{
				parameters.AddWithValue("@description", Item.Description);
				parameters.AddWithValue("@imgUrl", Item.ImgUrl);
				parameters.AddWithValue("@name", Item.Name);
				parameters.AddWithValue("@price", Item.Price);
			});
		}

		public Item Delete(long id)
		{
			return base.ExecuteReaderSingle("DeleteCatalogueItem", parameters =>
			{
				parameters.AddWithValue("@id", id);
			});
		}

		public List<Item> GetAll(long limit, long offset)
		{
			return base.ExecuteReaderCollection("GetCatalogue", parameters =>
			{
				parameters.AddWithValue("@limit", limit);
				parameters.AddWithValue("@offset", offset);
			});
		}

		public Item GetById(long id)
		{
			return base.ExecuteReaderSingle("GetCatalogueItem", parameters =>
			{
				parameters.AddWithValue("@id", id);
			});
		}

		public Item Update(Item Item)
		{
			return base.ExecuteReaderSingle("UpdateCatalogueItem", parameters =>
			{
				parameters.AddWithValue("@description", Item.Description);
				parameters.AddWithValue("@imgUrl", Item.ImgUrl);
				parameters.AddWithValue("@name", Item.Name);
				parameters.AddWithValue("@price", Item.Price);
				parameters.AddWithValue("@id", Item.Id);
			});
		}

		protected override Item ReadEntity(SqlDataReader reader)
		{
			return new Item
			{
				Id = (long)reader["id"],
				Description = (string)reader["description"],
				ImgUrl = (string)reader["imgUrl"],
				Name = (string)reader["name"],
				Price = (decimal)reader["price"],
			};
		}
	}
}
