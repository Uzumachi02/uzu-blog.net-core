using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Services;

public interface IPostService {

  Task<PostsReponse> GetListAsync(PostListRequest req);
}
