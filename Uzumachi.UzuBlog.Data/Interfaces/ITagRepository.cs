using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ITagRepository {

  Task<TagEntity> GetByIdAsync(int id);

  Task<IEnumerable<TagEntity>> GetListByNames(IEnumerable<string> tagNames);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(TagEntity tag, CancellationToken token, IDbTransaction? transaction = null);
}
