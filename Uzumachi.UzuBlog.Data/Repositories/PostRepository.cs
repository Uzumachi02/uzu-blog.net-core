using Dapper;
using System.Data;
using System.Text;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Data.Models;
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

  public async Task<PostExtendentEntity?> GetByIdWithUserAsync(int id) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(UserEntity.TABLE).Append(" AS u ON u.id = p.user_id ")
      .Append("WHERE p.id = @id LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, UserEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, user) => { post.User = user; return post; }, new { id });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByIdWithCategoryAsync(int id) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(CategoryEntity.TABLE).Append(" AS c ON c.id = p.category_id ")
      .Append("WHERE p.id = @id LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, CategoryEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, category) => { post.Category = category; return post; }, new { id });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByIdWithUserAndCategoryAsync(int id) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(UserEntity.TABLE).Append(" AS u ON u.id = p.user_id ")
      .Append("LEFT JOIN ").Append(CategoryEntity.TABLE).Append(" AS c ON c.id = p.category_id ")
      .Append("WHERE p.id = @id LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, UserEntity, CategoryEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, user, category) => { post.User = user; post.Category = category; return post; }, new { id });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByIdWithIncludesAsync(int id, PostIncludesModel includes) {
    if( includes.IncludeUser && includes.IncludeCategory ) {
      return await GetByIdWithUserAndCategoryAsync(id);
    }

    if( includes.IncludeUser ) {
      return await GetByIdWithUserAsync(id);
    }

    if( includes.IncludeCategory ) {
      return await GetByIdWithCategoryAsync(id);
    }

    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostExtendentEntity>(sql, new { id });
  }

  public async Task<PostEntity?> GetByAliasAsync(string alias) {
    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE alias = @alias;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostEntity>(sql, new { alias });
  }

  public async Task<PostExtendentEntity?> GetByAliasWithUserAsync(string alias) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(UserEntity.TABLE).Append(" AS u ON u.id = p.user_id ")
      .Append("WHERE p.alias = @alias LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, UserEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, user) => { post.User = user; return post; }, new { alias });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByAliasWithCategoryAsync(string alias) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(CategoryEntity.TABLE).Append(" AS c ON c.id = p.category_id ")
      .Append("WHERE p.alias = @alias LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, CategoryEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, category) => { post.Category = category; return post; }, new { alias });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByAliasWithUserAndCategoryAsync(string alias) {
    var sqlBuilder = new StringBuilder();

    sqlBuilder
      .Append("SELECT * FROM ").Append(PostEntity.TABLE).Append(" AS p ")
      .Append("LEFT JOIN ").Append(UserEntity.TABLE).Append(" AS u ON u.id = p.user_id ")
      .Append("LEFT JOIN ").Append(CategoryEntity.TABLE).Append(" AS c ON c.id = p.category_id ")
      .Append("WHERE p.alias = @alias LIMIT 1;");

    var response = await _dbConnection
      .QueryAsync<PostExtendentEntity, UserEntity, CategoryEntity, PostExtendentEntity>(sqlBuilder.ToString(),
        (post, user, category) => { post.User = user; post.Category = category; return post; }, new { alias });

    return response.FirstOrDefault();
  }

  public async Task<PostExtendentEntity?> GetByAliasWithIncludesAsync(string alias, PostIncludesModel includes) {
    if( includes.IncludeUser && includes.IncludeCategory ) {
      return await GetByAliasWithUserAndCategoryAsync(alias);
    }

    if( includes.IncludeUser ) {
      return await GetByAliasWithUserAsync(alias);
    }

    if( includes.IncludeCategory ) {
      return await GetByAliasWithCategoryAsync(alias);
    }

    var sql = $"SELECT * FROM {PostEntity.TABLE} WHERE alias = @alias;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostExtendentEntity>(sql, new { alias });
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

  public async Task<IEnumerable<PostEntity>> GetByCategoriesIdsAsync(IEnumerable<int> categoriesId, int limit = 20) {
    var sql = "SELECT * FROM get_posts_by_categories_ids(@categoriesId, @limit)";

    return await _dbConnection.QueryAsync<PostEntity>(sql, new {
      categoriesId = categoriesId.ToArray(),
      limit
    });
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

  public async Task<int> IncrementViewsCountByIdAsync(int id, CancellationToken cancellationToken, IDbTransaction? transaction = null) {
    var sql = $"UPDATE {PostEntity.TABLE} SET view_count = view_count + 1 WHERE id = @id RETURNING view_count;";

    return await _dbConnection.ExecuteScalarAsync<int>(
      new CommandDefinition(sql, new { id }, transaction, cancellationToken: cancellationToken)
    );
  }
}
