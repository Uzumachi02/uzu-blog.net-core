using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PostsCategoriesViewModel : BaseViewModel {

  public IEnumerable<CategoryDto>? Categories { get; set; }

  public static PostsCategoriesViewModel CreateByCategoriesReponse(CategoriesReponse categoriesReponse) {
    PostsCategoriesViewModel result = new();

    result.Categories = categoriesReponse.GroupingItems();

    return result;
  }
}
