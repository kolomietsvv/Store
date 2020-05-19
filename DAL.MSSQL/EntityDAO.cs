using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

		protected abstract T ReadEntity(SqlDataReader reader);

		private SqlDataReader ExecuteStoredProcedure(Action<SqlParameterCollection> parametersConfigurator,
			SqlConnection connection, string storedProcedureName)
		{
			connection.Open();
			SqlCommand command = new SqlCommand(storedProcedureName, connection);
			parametersConfigurator?.Invoke(command.Parameters);
			SqlDataReader reader = command.ExecuteReader();
			return reader;
		}
	}
}
