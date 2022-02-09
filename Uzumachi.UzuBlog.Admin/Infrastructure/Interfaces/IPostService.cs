using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Interfaces;

public interface IPostService {

  Task<PostDto?> GetByIdAsync(int id);

  Task<PostsReponse> GetListAsync(PostListRequest req);
}
