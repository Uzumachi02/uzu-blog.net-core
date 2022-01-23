namespace Uzumachi.UzuBlog.Web.Infrastructure.Builders;

public static partial class LinkBuilder {

  public static class User {

    public static string Details(string username) {
      return $"/user/{username}";
    }
  }
}

