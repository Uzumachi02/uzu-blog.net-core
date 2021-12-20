using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class CategoryService : ICategoryService {

  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<CategoryDto?> GetByAliasAsync(string alias) {
    var category = await _unitOfWork.Categories.GetByAliasAsync(alias);

    return category.AdaptToCategoryDto();
  }
}
