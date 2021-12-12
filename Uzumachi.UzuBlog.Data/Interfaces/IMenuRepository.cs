using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IMenuRepository {

  Task<MenuEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(MenuEntity menu, CancellationToken token, IDbTransaction? transaction = null);
}
