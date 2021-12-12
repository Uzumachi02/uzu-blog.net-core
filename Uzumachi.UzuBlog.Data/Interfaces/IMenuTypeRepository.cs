using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IMenuTypeRepository {

  Task<MenuTypeEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(MenuTypeEntity menutype, CancellationToken token, IDbTransaction? transaction = null);
}
