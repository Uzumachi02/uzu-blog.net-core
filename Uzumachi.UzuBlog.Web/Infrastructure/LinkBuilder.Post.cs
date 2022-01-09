using Microsoft.AspNetCore.WebUtilities;

namespace Uzumachi.UzuBlog.Web.Infrastructure;

public static partial class LinkBuilder {

  public static class Post {

    public static string List(int page = 0, int limit = 0) {
      string url = "/posts";

      if( page > 1 ) {
        url = QueryHelpers.AddQueryString(url, "page", page.ToString());
      }

      if( limit > 0 ) {
        url = QueryHelpers.AddQueryString(url, "limit", limit.ToString());
      }

      return url;
    }
  }
}