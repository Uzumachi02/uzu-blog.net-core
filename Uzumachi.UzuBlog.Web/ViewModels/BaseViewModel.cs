using Uzumachi.UzuBlog.Web.Models;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class BaseViewModel {

  private BreadcrumbModel? _breadcrumb;

  public string? Title { get; set; }

  public string? H1 { get; set; }

  public string? MetaDescription { get; set; }

  public BreadcrumbModel Breadcrumb {
    get {
      if( _breadcrumb is null ) {
        _breadcrumb = new BreadcrumbModel();
        _breadcrumb.Add("Home", "/");
      }

      return _breadcrumb;
    }
  }
}
