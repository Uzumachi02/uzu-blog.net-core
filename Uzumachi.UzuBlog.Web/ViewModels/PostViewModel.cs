using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Web.Infrastructure;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PostViewModel : BaseViewModel {

  public int PostId { get; set; }

  public string? Content { get; set; }

  public string? Excerpt { get; set; }

  public PostViewModel(PostDto postDto) {
    PostId = postDto.Id;
    Content = postDto.Content;
    Excerpt = postDto.Excerpt;
    Title = postDto.Title;
    H1 = postDto.Title;

    Breadcrumb.Add("Posts", LinkBuilder.Post.List());

    if( postDto.Category != null ) {
      Breadcrumb.Add(postDto.Category.Title, LinkBuilder.Post.CategoryList(postDto.Category.Alias));
    }

    Breadcrumb.Add(Title);

    OpenGraphProtocol
      .SetType("article")
      .SetTitle(postDto.Title);
  }
}
