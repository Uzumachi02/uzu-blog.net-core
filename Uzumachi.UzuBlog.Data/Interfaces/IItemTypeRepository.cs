using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IItemTypeRepository {

  Task<ItemTypeEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(ItemTypeEntity itemtype, CancellationToken token, IDbTransaction? transaction = null);
}
