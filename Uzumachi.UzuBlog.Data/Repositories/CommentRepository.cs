using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class CommentRepository : ICommentRepository {

  private readonly IDbConnection _dbConnection;

  public CommentRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<CommentEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {CommentEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<CommentEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(CommentEntity comment, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
