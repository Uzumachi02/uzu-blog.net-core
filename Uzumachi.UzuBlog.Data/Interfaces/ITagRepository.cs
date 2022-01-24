using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ITagRepository {

  Task<TagEntity> GetByIdAsync(int id);

  Task<TagEntity?> GetByAliasAsync(string alias);

  Task<IEnumerable<TagEntity>> GetListByIdsAsync(IEnumerable<int> ids);

  Task<IEnumerable<TagEntity>> GetListByNames(IEnumerable<string> tagNames);

  Task<int> GetListCountAsync(TagFilters filters);

  Task<IEnumerable<TagEntity>> GetListAsync(TagFilters filters);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(TagEntity tag, CancellationToken token, IDbTransaction? transaction = null);
}
