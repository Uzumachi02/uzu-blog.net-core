using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ICommentRepository {

  Task<CommentEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(CommentEntity comment, CancellationToken token, IDbTransaction? transaction = null);
}
