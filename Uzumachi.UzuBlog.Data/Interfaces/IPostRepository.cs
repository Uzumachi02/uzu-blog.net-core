using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IPostRepository {

  Task<PostEntity> GetByIdAsync(int id);

  Task<IEnumerable<PostEntity>> GetListAsync(PostFilters filters);

  Task<int> GetListCountAsync(PostFilters filters);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null);
}
