using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Web.Infrastructure.Builders;
using Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class TagViewModel : BaseViewModel {

  public TagDto Tag { get; set; }

  public TagViewModel(TagDto tag) {
    Tag = tag;
    Title = tag.Title;

    Breadcrumb.Add("Tags", LinkBuilder.Tag.List());
    Breadcrumb.Add(tag.Title);
  }

  public IEnumerable<PostDto>? Posts { get; set; }


  public TagViewModel SetPostsFromPostsReponse(PostsReponse postsReponse) {
    Posts = postsReponse.GroupingItems();

    return this;
  }
}
