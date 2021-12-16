using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Web.Models;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class BaseViewModel {

  private BreadcrumbModel? _breadcrumb;

  private OpenGraphProtocolModel? _openGraphProtocol;

  private Dictionary<string, string>? _metadata;

  private Dictionary<string, string>? _metaProperties;

  public string? Title { get; set; }

  public string? H1 { get; set; }

  public string? MetaOthers { get; set; }

  public Dictionary<string, string> Metadata => _metadata ??= new();

  public Dictionary<string, string> MetaProperties => _metaProperties ??= new();

  public OpenGraphProtocolModel OpenGraphProtocol => _openGraphProtocol ??= new(MetaProperties);

  public BreadcrumbModel Breadcrumb {
    get {
      if( _breadcrumb is null ) {
        _breadcrumb = new BreadcrumbModel();
        _breadcrumb.Add("Home", "/");
      }

      return _breadcrumb;
    }
  }

  public BaseViewModel AddMetadata(string name, string value) {
    Metadata[name] = value;

    return this;
  }

  public BaseViewModel AddMetaDescription(string value) {
    Metadata["description"] = value;

    return this;
  }

  public BaseViewModel AddMetaKeywords(string value) {
    Metadata["keywords"] = value;

    return this;
  }

  public void SetSeo(SeoDto seo) {
    if( !string.IsNullOrWhiteSpace(seo.Title) ) {
      Title = seo.Title;
    }

    if( !string.IsNullOrWhiteSpace(seo.H1) ) {
      H1 = seo.H1;
    }

    if( !string.IsNullOrWhiteSpace(seo.Description) ) {
      AddMetaDescription(seo.Description);
    }

    if( !string.IsNullOrWhiteSpace(seo.Keywords) ) {
      AddMetaKeywords(seo.Keywords);
    }

    if( !string.IsNullOrWhiteSpace(seo.Others) ) {
      MetaOthers = seo.Others;
    }
  }
}
