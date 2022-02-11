using Uzumachi.UzuBlog.Admin.Infrastructure.Models;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Helpers;

public static class TreeSelectHelpers {

  public static List<TreeSelectItemModel> GetTreeSelectItemModelByCategoryDtos(IEnumerable<CategoryDto> categories) {
    return GetParentsWithChildren(categories.Select(category => new TreeSelectItemModel {
      Id = category.Id,
      ParentId = category.ParentId,
      Title = category.Title
    }).ToList());
  }

  public static List<TreeSelectItemModel> GetParentsWithChildren(List<TreeSelectItemModel> items) {
    items.ToList().ForEach(i => i.Children = items.Where(ic => ic.ParentId == i.Id).ToList());

    return items.Where(c => c.ParentId == 0).ToList();
  }
}
