using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IUserAgentRepository {

  Task<UserAgentEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(UserAgentEntity useragent, CancellationToken token, IDbTransaction? transaction = null);
}
