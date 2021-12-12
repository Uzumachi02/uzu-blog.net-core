using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class LanguageRepository : ILanguageRepository {

  private readonly IDbConnection _dbConnection;

  public LanguageRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<LanguageEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {LanguageEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<LanguageEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(LanguageEntity language, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
