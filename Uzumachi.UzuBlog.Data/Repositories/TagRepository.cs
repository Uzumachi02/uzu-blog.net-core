using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class TagRepository : ITagRepository {

  private readonly IDbConnection _dbConnection;

  public TagRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<TagEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {TagEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<TagEntity>(sql, new { id });
  }

  public async Task<TagEntity?> GetByAliasAsync(string alias) {
    var sql = $"SELECT * FROM {TagEntity.TABLE} WHERE alias = @alias and is_deleted = false;";

    return await _dbConnection.QueryFirstOrDefaultAsync<TagEntity>(sql, new { alias });
  }

  public async Task<IEnumerable<TagEntity>> GetListByIdsAsync(IEnumerable<int> ids) {
    var sql = $"SELECT * FROM {TagEntity.TABLE} WHERE id = ANY(@ids);";

    return await _dbConnection.QueryAsync<TagEntity>(sql, new { ids = ids.ToArray() });
  }

  public async Task<IEnumerable<TagEntity>> GetListByNames(IEnumerable<string> tagNames) {
    var sql = $"SELECT * FROM {TagEntity.TABLE} WHERE LOWER(title) = ANY(@tagNames);";

    return await _dbConnection.QueryAsync<TagEntity>(sql, new { tagNames = tagNames.Select(x => x.Trim().ToLower()).ToArray() });
  }

  public async Task<int> CreateAsync(TagEntity tag, CancellationToken token, IDbTransaction? transaction = null) {
    tag.CreateDate = tag.UpdateDate = DateTime.UtcNow;

    var sql = $"INSERT INTO {TagEntity.TABLE} " +
        "(language_id, alias, title, create_date, update_date) VALUES " +
        "(@LanguageId, @Alias, @Title, @CreateDate, @UpdateDate) RETURNING ID;";

    var resId = await _dbConnection.ExecuteScalarAsync<int>(
      new CommandDefinition(sql, tag, transaction, cancellationToken: token)
    );

    tag.Id = resId;

    return resId;
  }
}
