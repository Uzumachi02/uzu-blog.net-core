using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IPostRepository {

  Task<PostEntity> GetByIdAsync(int id);

  Task<PostEntity?> GetByAliasAsync(string alias);

  Task<IEnumerable<PostEntity>> GetListAsync(PostFilters filters);

  Task<int> GetListCountAsync(PostFilters filters);

  Task<IEnumerable<PostEntity>> GetByCategoriesIdsAsync(IEnumerable<int> categoriesId, int limit = 20);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null);

  Task<int> IncrementViewsCountByIdAsync(int id, CancellationToken cancellationToken, IDbTransaction? transaction = null);
}
