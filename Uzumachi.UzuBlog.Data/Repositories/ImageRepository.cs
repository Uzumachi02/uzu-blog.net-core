using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class ImageRepository : IImageRepository {

  private readonly IDbConnection _dbConnection;

  public ImageRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<ImageEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {ImageEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<ImageEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(ImageEntity image, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }
}
