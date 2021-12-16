using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class PostRepository : IPostRepository {

  private readonly IDbConnection _dbConnection;

  public PostRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<PostEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostEntity>(sql, new { id });
  }

  public async Task<PostEntity?> GetByAliasAsync(string alias) {
    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE alias = @alias;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostEntity>(sql, new { alias });
  }

  public async Task<IEnumerable<PostEntity>> GetListAsync(PostFilters filters) {
    var sql = $"SELECT * FROM {PostEntity.TABLE} AS base WHERE base.is_deleted = false";
    var parameters = new DynamicParameters();

    sql += filters.GetWhereSql(parameters, true);
    sql += filters.GetOrderSql();
    sql += filters.GetLimitSql();

    return await _dbConnection.QueryAsync<PostEntity>(sql, parameters);
  }

  public async Task<int> GetListCountAsync(PostFilters filters) {
    var sql = $"SELECT COUNT(*) FROM {PostEntity.TABLE} AS base WHERE base.is_deleted = false";
    var parameters = new DynamicParameters();

    sql += filters.GetWhereSql(parameters, true);

    return await _dbConnection.ExecuteScalarAsync<int>(sql, parameters);
  }

  public async Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null) {
    post.CreateDate = post.UpdateDate = post.PublishDate = DateTime.UtcNow;

    var sql = $"INSERT INTO {PostEntity.TABLE} " +
        "(user_id, category_id, language_id, image_id, alias, title, excerpt, content, image, close_comments, status, create_date, publish_date, update_date) VALUES " +
        "(@UserId, @CategoryId, @LanguageId, @ImageId, @Alias, @Title, @Excerpt, @Content, @Image, @CloseComments, @Status, @CreateDate, @PublishDate, @UpdateDate) RETURNING ID;";

    var resId = await _dbConnection.ExecuteScalarAsync<int>(
      new CommandDefinition(sql, post, transaction, cancellationToken: token)
    );

    post.Id = resId;

    return resId;
  }
}
