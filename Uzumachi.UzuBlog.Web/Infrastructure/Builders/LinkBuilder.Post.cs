using Microsoft.AspNetCore.WebUtilities;

namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static class Post {

    public static string List(int page = 0, int limit = 0) {
      string url = "/posts";

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

    public static string CategoryList(string categoryAlias, int page = 0, int limit = 0) {
      string url = "/posts/" + categoryAlias;

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

    public static string Details(string categoryAlias, string postAlias) {
      return $"/post/{categoryAlias}/{postAlias}";
    }
  }
}