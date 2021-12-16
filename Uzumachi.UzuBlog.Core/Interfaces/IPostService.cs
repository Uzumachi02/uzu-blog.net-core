using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IPostService {

  public Task<ItemsResponse<PostDto>> GetListAsync(PostListRequest req);
}

