using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Data.Models;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IPostRepository {

  Task<PostEntity> GetByIdAsync(int id);

  Task<PostExtendentEntity?> GetByIdWithUserAsync(int id);

  Task<PostExtendentEntity?> GetByIdWithCategoryAsync(int id);

  Task<PostExtendentEntity?> GetByIdWithUserAndCategoryAsync(int id);

  Task<PostExtendentEntity?> GetByIdWithIncludesAsync(int id, PostIncludesModel includes);

  Task<PostEntity?> GetByAliasAsync(string alias);

  Task<PostExtendentEntity?> GetByAliasWithUserAsync(string alias);

  Task<PostExtendentEntity?> GetByAliasWithCategoryAsync(string alias);

  Task<PostExtendentEntity?> GetByAliasWithUserAndCategoryAsync(string alias);

  Task<PostExtendentEntity?> GetByAliasWithIncludesAsync(string alias, PostIncludesModel includes);

  Task<IEnumerable<PostEntity>> GetListAsync(PostFilters filters);

  Task<int> GetListCountAsync(PostFilters filters);

  Task<IEnumerable<PostEntity>> GetByCategoriesIdsAsync(IEnumerable<int> categoriesId, int limit = 20);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null);

  Task<int> IncrementViewsCountByIdAsync(int id, CancellationToken cancellationToken, IDbTransaction? transaction = null);
}
