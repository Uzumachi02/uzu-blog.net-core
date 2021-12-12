using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class MenuTypeRepository : IMenuTypeRepository {

  private readonly IDbConnection _dbConnection;

  public MenuTypeRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<MenuTypeEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {MenuTypeEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<MenuTypeEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(MenuTypeEntity menutype, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
