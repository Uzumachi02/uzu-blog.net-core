using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class LanguageResourceRepository : ILanguageResourceRepository {

  private readonly IDbConnection _dbConnection;

  public LanguageResourceRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<LanguageResourceEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {LanguageResourceEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<LanguageResourceEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(LanguageResourceEntity languageresource, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
