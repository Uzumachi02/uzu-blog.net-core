using Uzumachi.UzuBlog.Web.Models;
using Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public sealed class PaginationBuilder {

  private string KeyPage = "page";

  private string KeyLimit = "limit";

  private string BaseUrl = "";

  private int CurrentPage;

  private int TotalCount;

  private int PageSize;

  private Dictionary<string, string>? RequestValues = null;

  public PaginationBuilder SetCurrentPage(int currentPage) {
    CurrentPage = currentPage;

    return this;
  }

  public PaginationBuilder SetTotalCount(int totalCount) {
    TotalCount = totalCount;

    return this;
  }

  public PaginationBuilder SetPageSize(int pageSize) {
    PageSize = pageSize;

    return this;
  }

  public PaginationBuilder SetBaseUrl(string baseUrl) {
    BaseUrl = baseUrl;

    return this;
  }

  public PaginationBuilder SetRequestValues(Dictionary<string, string> requestValues) {
    RequestValues = requestValues;

    return this;
  }

  public PaginationBuilder AddRequestValues(Dictionary<string, string> requestValues) {
    if( RequestValues is null ) {
      RequestValues = new();
    }

    foreach( var item in requestValues ) {
      RequestValues[item.Key] = item.Value;
    }

    return this;
  }

  public PaginationBuilder AddRequestValue(string name, string value) {
    if( RequestValues is null ) {
      RequestValues = new();
    }

    RequestValues[name] = value;

    return this;
  }

  public PaginationModel Build() {
    return new PaginationModel(TotalCount, CurrentPage, PageSize, BaseUrl, RequestValues);
  }

  public PaginationModel BuildByRequest(HttpRequest request, int totalCount) {
    SetTotalCount(totalCount);

    if( CurrentPage == 0 ) {
      CurrentPage = request.TryGetQueryInt(KeyPage);
    }

    if( PageSize == 0 ) {
      PageSize = request.TryGetQueryInt(KeyLimit);
    }

    if( string.IsNullOrWhiteSpace(BaseUrl) ) {
      BaseUrl = request.Path.ToString();
    }

    if( RequestValues is null ) {
      RequestValues = request.GetRequestValues();
    }

    return new PaginationModel(TotalCount, CurrentPage, PageSize, BaseUrl, RequestValues);
  }
}
