using Data;
using System.Collections.Generic;

namespace BLL
{
	public interface ICatalogueService : IEntityService<Item, long>
	{
		List<Item> GetByIds(IEnumerable<long> ids);
	}
}
