using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IUserRepository {

  Task<UserEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(UserEntity user, CancellationToken token, IDbTransaction? transaction = null);
}
