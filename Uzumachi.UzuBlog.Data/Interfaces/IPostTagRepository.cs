using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IPostTagRepository {

  Task<PostTagEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(PostTagEntity posttag, CancellationToken token, IDbTransaction? transaction = null);

  /// <returns>count new item.</returns>
  Task<int> AddTagsToPost(IEnumerable<int> tagIds, int postId, CancellationToken cancellationToken, IDbTransaction? transaction = null);
}
