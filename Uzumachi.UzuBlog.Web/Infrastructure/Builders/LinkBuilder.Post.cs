using Microsoft.AspNetCore.WebUtilities;

namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static class Post {

    public static string List(int page = 0, int limit = 0) {
      return LinkBuilder.List("/posts", page, limit);
    }

    public static string CategoryList(string categoryAlias, int page = 0, int limit = 0) {
      return LinkBuilder.List("/posts/" + categoryAlias, page, limit);
    }

    public static string Details(string categoryAlias, string postAlias) {
      return $"/post/{categoryAlias}/{postAlias}";
    }
  }
}