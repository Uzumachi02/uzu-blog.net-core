using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class CategoryRepository : ICategoryRepository {

  private readonly IDbConnection _dbConnection;

  public CategoryRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<CategoryEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {CategoryEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<CategoryEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(CategoryEntity category, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
