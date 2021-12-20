using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Domain.Responses;

public class PostsReponse : ItemsResponse<PostDto> {

  public IEnumerable<UserDto>? Users { get; set; }

  public IEnumerable<CategoryDto>? Categories { get; set; }
}
