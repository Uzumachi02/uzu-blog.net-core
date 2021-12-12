using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ICategoryRepository {

  Task<CategoryEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(CategoryEntity category, CancellationToken token, IDbTransaction? transaction = null);
}
