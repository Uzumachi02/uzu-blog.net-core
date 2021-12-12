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

  public Task<int> CreateAsync(UserEntity user, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
