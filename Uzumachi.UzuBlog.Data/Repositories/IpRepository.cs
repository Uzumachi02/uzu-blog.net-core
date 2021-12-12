using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class IpRepository : IIpRepository {

  private readonly IDbConnection _dbConnection;

  public IpRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<IpEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {IpEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<IpEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(IpEntity ip, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
