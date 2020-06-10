using Data;
using System.Collections.Generic;

namespace DAL.Contracts
{
	public interface ICatalogueDAO : IEntityDAO<Item, long>
	{
		List<Item> GetByIds(IEnumerable<long> ids);
	}
}
