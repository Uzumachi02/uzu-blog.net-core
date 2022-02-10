using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Domain.Responses;

public class PostReponse: ItemResponse<PostDto> {

  public UserDto? User { get; set; }

  public CategoryDto? Category { get; set; }

  public IEnumerable<TagDto>? Tags { get; set; }
}
