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

  public async Task<CategoryEntity?> GetByAliasAsync(string alias) {
    var sql = $"SELECT * FROM {CategoryEntity.TABLE} WHERE alias = @alias;";

    return await _dbConnection.QueryFirstOrDefaultAsync<CategoryEntity>(sql, new { alias });
  }

  public async Task<int> CreateAsync(CategoryEntity category, CancellationToken token, IDbTransaction? transaction = null) {
    category.CreateDate = category.UpdateDate = DateTime.UtcNow;

    var sql = $"INSERT INTO {CategoryEntity.TABLE} " +
        "(parent_id, language_id, item_type_id, alias, title, display_order, status, create_date, update_date) VALUES " +
        "(@ParentId, @LanguageId, @ItemTypeId, @Alias, @Title, @DisplayOrder, @Status, @CreateDate, @UpdateDate) RETURNING ID;";

    var resId = await _dbConnection.ExecuteScalarAsync<int>(
      new CommandDefinition(sql, category, transaction, cancellationToken: token)
    );

    category.Id = resId;

    return resId;
  }
}
