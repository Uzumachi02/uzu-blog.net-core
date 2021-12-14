using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IPageRepository {

  Task<PageEntity> GetByIdAsync(int id);

  Task<PageEntity?> GetByAliasAsync(string alias);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(PageEntity page, CancellationToken token, IDbTransaction? transaction = null);
}
