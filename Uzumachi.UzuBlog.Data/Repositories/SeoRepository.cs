using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class SeoRepository : ISeoRepository {

  private readonly IDbConnection _dbConnection;

  public SeoRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<SeoEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {SeoEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<SeoEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(SeoEntity seo, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
