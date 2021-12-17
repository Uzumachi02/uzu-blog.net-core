using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IPostService {

  Task<PostDto?> GetByAliasAsync(string alias);

  Task<ItemsResponse<PostDto>> GetListAsync(PostListRequest req);

  Task<int> IncrementViewsCountById(int postId, CancellationToken cancellationToken = default);
}
