using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class ItemTypeRepository : IItemTypeRepository {

  private readonly IDbConnection _dbConnection;

  public ItemTypeRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<ItemTypeEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {ItemTypeEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<ItemTypeEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(ItemTypeEntity itemtype, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
