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

  public Task<int> CreateAsync(PostEntity post, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
