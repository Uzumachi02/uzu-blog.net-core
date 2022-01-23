namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static class Tag {

    public static string Details(string alias) {
      return $"/tag/{alias}";
    }
  }
}
