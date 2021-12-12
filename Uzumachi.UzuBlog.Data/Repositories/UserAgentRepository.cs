using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class UserAgentRepository : IUserAgentRepository {

  private readonly IDbConnection _dbConnection;

  public UserAgentRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<UserAgentEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {UserAgentEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<UserAgentEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(UserAgentEntity useragent, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
