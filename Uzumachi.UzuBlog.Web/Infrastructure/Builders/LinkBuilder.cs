using Microsoft.AspNetCore.WebUtilities;

namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static string Home() => "/";

  public static string List(string url, int page = 0, int limit = 0) {
    if( page > 1 || limit > 0 ) {
      Dictionary<string, string?> queryStrings = new();

      if( page > 1 ) {
        queryStrings.Add("page", page.ToString());
      }

      if( limit > 0 ) {
        queryStrings.Add("limit", limit.ToString());
      }

      url = QueryHelpers.AddQueryString(url, queryStrings);
    }

    return url;
  }
}
