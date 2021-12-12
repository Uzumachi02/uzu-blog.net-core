using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ILikeRepository {

  Task<LikeEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(LikeEntity like, CancellationToken token, IDbTransaction? transaction = null);
}
