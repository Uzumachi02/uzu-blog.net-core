namespace Uzumachi.UzuBlog.Web.Models;

public class BreadcrumbItemModel {

  /// <summary>
  /// Название ссылки.
  /// </summary>
  public string Title;

  /// <summary>
  /// Ссылка.
  /// </summary>
  public string? Link;

  public bool IsActive;

  public bool HasLink => !string.IsNullOrWhiteSpace(Link);


  public BreadcrumbItemModel(string title) {
    Title = title;
    IsActive = true;
  }

  public BreadcrumbItemModel(string title, string link, bool isActive = false) {
    Title = title;
    Link = link;
    IsActive = isActive;
  }
}
