using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class LanguageItemConnectionRepository : ILanguageItemConnectionRepository {

  private readonly IDbConnection _dbConnection;

  public LanguageItemConnectionRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<LanguageItemConnectionEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {LanguageItemConnectionEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<LanguageItemConnectionEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(LanguageItemConnectionEntity languageitemconnection, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
