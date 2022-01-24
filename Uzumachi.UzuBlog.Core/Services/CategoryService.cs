using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Services;

public class CategoryService : ICategoryService {

  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<CategoryDto?> GetByAliasAsync(string alias) {
    var category = await _unitOfWork.Categories.GetByAliasAsync(alias);

    return category.AdaptToCategoryDto();
  }

  public async Task<CategoriesReponse> GetListAsync(CategoryListRequest req) {
    var filters = req.AdaptToCategoryFilters();
    var countCategories = await _unitOfWork.Categories.GetListCountAsync(filters);

    var response = new CategoriesReponse {
      Count = countCategories
    };

    if( countCategories == 0 ) {
      response.Items = Array.Empty<CategoryDto>();

      return response;
    }

    var dbCategories = await _unitOfWork.Categories.GetListAsync(filters);
    var categories = dbCategories.Select(x => x.AdaptToCategoryDto()).ToArray();

    if( req.IncludePosts > 0 ) {
      response.Posts = await GetPostsFromCategories(categories, req.PostsLimit);
    }

    response.Items = categories;
    return response;
  }

  public async Task<IEnumerable<PostDto>?> GetPostsFromCategories(IEnumerable<CategoryDto> categories, int postsLimit = 20) {
    var categoriesId = categories.Select(p => p.Id).Distinct();
    var dbPosts = await _unitOfWork.Posts.GetByCategoriesIdsAsync(categoriesId, postsLimit);

    return dbPosts.Select(p => p.AdaptToPostDto());
  }
}
