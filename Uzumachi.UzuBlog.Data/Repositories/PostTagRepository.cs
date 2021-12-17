using Dapper;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Repositories;

public class PostTagRepository : IPostTagRepository {

  private readonly IDbConnection _dbConnection;

  public PostTagRepository(IDbConnection dbConnection) =>
    _dbConnection = dbConnection;

  public async Task<PostTagEntity> GetByIdAsync(int id) {
    var sql = $"SELECT * FROM {PostTagEntity.TABLE} WHERE id = @id;";

    return await _dbConnection.QueryFirstOrDefaultAsync<PostTagEntity>(sql, new { id });
  }

  public Task<int> CreateAsync(PostTagEntity posttag, CancellationToken token, IDbTransaction? transaction = null) {
    throw new NotImplementedException();
  }

  public async Task<int> AddTagsToPost(IEnumerable<int> tagIds, int postId, CancellationToken cancellationToken, IDbTransaction? transaction = null) {
    var sql = $"INSERT INTO {PostTagEntity.TABLE} (post_id, tag_id) VALUES (@PostId, @TagId)";
    var tags = new List<PostTagEntity>();

    foreach( var tagId in tagIds ) {
      tags.Add(new() { PostId = postId, TagId = tagId });
    }

    return await _dbConnection.ExecuteAsync(
      new CommandDefinition(sql, tags, transaction, cancellationToken: cancellationToken)
    );
  }
}
