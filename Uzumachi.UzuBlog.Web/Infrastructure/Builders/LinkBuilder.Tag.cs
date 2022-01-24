namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static class Tag {

    public static string List(int page = 0, int limit = 0) {
      return LinkBuilder.List("/tags", page, limit);
    }

    public static string Details(string alias) {
      return $"/tag/{alias}";
    }
  }
}
