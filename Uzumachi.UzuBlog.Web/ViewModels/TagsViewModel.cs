using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class TagsViewModel : BaseViewModel {

  public IEnumerable<TagDto>? Tags { get; set; }

  public static TagsViewModel CreateByTagsReponse(TagsReponse tagsResponse) {
    TagsViewModel result = new();

    result.Title = "List of tags";
    result.Breadcrumb.Add("Tags");

    if( tagsResponse.Items != null) {
      result.Tags = tagsResponse.Items;
    }

    return result;
  }
}
