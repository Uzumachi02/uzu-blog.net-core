using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class PostTagRepository : IPostTagRepository {

  private readonly IDbConnection _dbConnection;

  public PostTagRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<PostTagEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {PostTagEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostTagEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(PostTagEntity posttag, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
