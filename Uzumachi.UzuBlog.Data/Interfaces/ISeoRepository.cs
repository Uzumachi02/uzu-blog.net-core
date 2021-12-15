using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ISeoRepository {

  Task<SeoEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(SeoEntity seo, CancellationToken token, IDbTransaction? transaction = null);

  Task<SeoEntity?> GetByUrlAsync(string url);
}
