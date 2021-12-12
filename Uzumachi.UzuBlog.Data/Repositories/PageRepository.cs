using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class PageRepository : IPageRepository {

  private readonly IDbConnection _dbConnection;

  public PageRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<PageEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {PageEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PageEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(PageEntity page, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
