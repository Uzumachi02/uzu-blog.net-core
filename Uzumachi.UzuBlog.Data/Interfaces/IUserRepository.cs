using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IUserRepository {

  Task<UserEntity> GetByIdAsync(int id);

  Task<UserEntity?> GetByUsernameAsync(string username);

  Task<IEnumerable<UserEntity>> GetListByIdsAsync(IEnumerable<int> ids);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(UserEntity user, CancellationToken token, IDbTransaction? transaction = null);
}
