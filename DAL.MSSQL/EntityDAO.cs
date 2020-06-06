using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.MSSQL
{
	public abstract class EntityDAO<T>
		where T : new()
	{
		protected string connectionString;

		public EntityDAO(string connectionString)
		{
			this.connectionString = connectionString;
		}

		protected T ExecuteReaderSingle(string storedProcedureName, Action<SqlParameterCollection> parametersConfigurator)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataReader reader = ExecuteStoredProcedure(parametersConfigurator, connection, storedProcedureName);
				while (reader.Read())
				{
					return ReadEntity(reader);
				}
				return default;
			}
		}

		protected List<T> ExecuteReaderCollection(string storedProcedureName, Action<SqlParameterCollection> parametersConfigurator)
		{
			var result = new List<T>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataReader reader = ExecuteStoredProcedure(parametersConfigurator, connection, storedProcedureName);
				while (reader.Read())
				{
					result.Add(ReadEntity(reader));
				}
			}
			return result;
		}

		protected List<T> ExecuteReaderCollectionGrouping<TItem, TKey>(string storedProcedureName,
			Action<SqlParameterCollection> parametersConfigurator,
			Func<SqlDataReader, TItem> readItem,
			Func<TItem, TKey> groupBy,
			Func<IGrouping<TKey, TItem>, T> agregate)
		{
			if (readItem == null)
			{
				return null;
			}
			var result = new List<TItem>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataReader reader = ExecuteStoredProcedure(parametersConfigurator, connection, storedProcedureName);
				while (reader.Read())
				{
					result.Add(readItem(reader));
				}
			}
			return result.GroupBy(groupBy).Select(agregate).ToList();
		}

		protected T ExecuteReaderGrouping<TItem, TKey>(string storedProcedureName,
			Action<SqlParameterCollection> parametersConfigurator,
			Func<SqlDataReader, TItem> readItem,
			Func<TItem, TKey> groupBy,
			Func<IGrouping<TKey, TItem>, T> agregate)
		{
			return ExecuteReaderCollectionGrouping(storedProcedureName,
				parametersConfigurator, readItem, groupBy, agregate).First();
		}

		protected abstract T ReadEntity(SqlDataReader reader);

		private SqlDataReader ExecuteStoredProcedure(Action<SqlParameterCollection> parametersConfigurator,
			SqlConnection connection, string storedProcedureName)
		{
			connection.Open();
			SqlCommand command = new SqlCommand(storedProcedureName, connection);
			command.CommandType = CommandType.StoredProcedure;
			parametersConfigurator?.Invoke(command.Parameters);
			SqlDataReader reader = command.ExecuteReader();
			return reader;
		}
	}
}
