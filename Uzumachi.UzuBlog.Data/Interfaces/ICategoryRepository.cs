using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ICategoryRepository {

  Task<CategoryEntity> GetByIdAsync(int id);

  Task<CategoryEntity?> GetByAliasAsync(string alias);

  Task<IEnumerable<CategoryEntity>> GetListByIdsAsync(IEnumerable<int> ids);

  Task<int> GetListCountAsync(CategoryFilters filters);

  Task<IEnumerable<CategoryEntity>> GetListAsync(CategoryFilters filters);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(CategoryEntity category, CancellationToken token, IDbTransaction? transaction = null);
}
