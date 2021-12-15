using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Web.Models;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class BaseViewModel {

  private BreadcrumbModel? _breadcrumb;

  public string? Title { get; set; }

  public string? H1 { get; set; }

  public string? MetaDescription { get; set; }

  public string? MetaKeywords { get; set; }

  public string? MetaOthers { get; set; }

  public BreadcrumbModel Breadcrumb {
    get {
      if( _breadcrumb is null ) {
        _breadcrumb = new BreadcrumbModel();
        _breadcrumb.Add("Home", "/");
      }

      return _breadcrumb;
    }
  }

  public void SetSeo(SeoDto seo) {
    if( !string.IsNullOrWhiteSpace(seo.Title) ) {
      Title = seo.Title;
    }

    if( !string.IsNullOrWhiteSpace(seo.H1) ) {
      H1 = seo.H1;
    }

    if( !string.IsNullOrWhiteSpace(seo.Description) ) {
      MetaDescription = seo.Description;
    }

    if( !string.IsNullOrWhiteSpace(seo.Keywords) ) {
      MetaKeywords = seo.Keywords;
    }

    if( !string.IsNullOrWhiteSpace(seo.Others) ) {
      MetaOthers = seo.Others;
    }
  }
}
