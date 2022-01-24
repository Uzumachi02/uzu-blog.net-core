using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Domain.Responses;

public class CategoriesReponse :ItemsResponse<CategoryDto> {

  public IEnumerable<PostDto>? Posts { get; set; }
}
