using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class PostRepository : IPostRepository {

  private readonly IDbConnection _dbConnection;

  public PostRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<PostEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
