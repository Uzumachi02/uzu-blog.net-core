using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class TagRepository : ITagRepository {

  private readonly IDbConnection _dbConnection;

  public TagRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<TagEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {TagEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<TagEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(TagEntity tag, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
