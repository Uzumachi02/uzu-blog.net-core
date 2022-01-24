using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface ICategoryService {

  Task<CategoryDto?> GetByAliasAsync(string alias);

  Task<CategoriesReponse> GetListAsync(CategoryListRequest req);

  Task<IEnumerable<PostDto>?> GetPostsFromCategories(IEnumerable<CategoryDto> categories, int postsLimit = 20);
}
