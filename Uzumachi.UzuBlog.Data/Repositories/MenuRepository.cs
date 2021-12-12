using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class MenuRepository : IMenuRepository {

  private readonly IDbConnection _dbConnection;

  public MenuRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<MenuEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {MenuEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<MenuEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(MenuEntity menu, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
