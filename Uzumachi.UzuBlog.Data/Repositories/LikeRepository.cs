using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class LikeRepository : ILikeRepository {

  private readonly IDbConnection _dbConnection;

  public LikeRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<LikeEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {LikeEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<LikeEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(LikeEntity like, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
