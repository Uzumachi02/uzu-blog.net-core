using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PageViewModel : BaseViewModel {

  public int PageId { get; set; }

  public string? Content { get; set; }

  public PageViewModel() { }

  public PageViewModel(PageDto pageDto) {
    PageId = pageDto.Id;
    Content = pageDto.Content;
    Title = pageDto.Title;
    H1 = pageDto.Title;

    Breadcrumb.Add(pageDto.Title);

    OpenGraphProtocol
      .SetType("article")
      .SetTitle(pageDto.Title);
  }
}
