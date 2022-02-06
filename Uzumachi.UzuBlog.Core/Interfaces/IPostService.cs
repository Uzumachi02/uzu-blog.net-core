using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IPostService {

  Task<PostDto?> GetByIdAsync(int id);

  Task<PostDto?> GetByAliasAsync(string alias);

  Task<PostsReponse> GetListAsync(PostListRequest req);

  Task<int> IncrementViewsCountById(int postId, CancellationToken cancellationToken = default);

  Task<IEnumerable<UserDto>?> GetUsersFromPosts(IEnumerable<PostDto> posts);

  Task<IEnumerable<CategoryDto>?> GetCategoriesFromPosts(IEnumerable<PostDto> posts);

  Task<IEnumerable<TagDto>?> GetTagsFromPosts(IEnumerable<PostDto> posts);
}
