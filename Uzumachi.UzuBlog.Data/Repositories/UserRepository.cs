using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class UserRepository : IUserRepository {

  private readonly IDbConnection _dbConnection;

  public UserRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<UserEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {UserEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<UserEntity>(sql, new { id });
  }

  public async Task<UserEntity?> GetByUsernameAsync(string username) {
    var sql = $"SELECT * FROM {UserEntity.TABLE} WHERE Lower(username) = @username;";

    return await _dbConnection.QueryFirstOrDefaultAsync<UserEntity>(sql, new {
      username = username.ToLower()
    });
  }

  public async Task<IEnumerable<UserEntity>> GetListByIdsAsync(IEnumerable<int> ids) {
    var sql = $"SELECT * FROM {UserEntity.TABLE} WHERE id = ANY(@ids);";

    return await _dbConnection.QueryAsync<UserEntity>(sql, new { ids = ids.ToArray() });
  }

  public Task<int> CreateAsync(UserEntity user, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
