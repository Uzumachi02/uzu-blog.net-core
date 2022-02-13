namespace Uzumachi.UzuBlog.Admin.Infrastructure.Models;

public class BreadcrumbModel {

  public List<BreadcrumbItemModel> Items { get; set; }

  public int Count => Items?.Count ?? 0;

  public BreadcrumbModel() {
    Items = new List<BreadcrumbItemModel>();
  }

  public BreadcrumbModel Add(string title) {
    Items.Add(new BreadcrumbItemModel(title));

    return this;
  }

  public BreadcrumbModel Add(string title, string link, bool isActive = false) {
    Items.Add(new BreadcrumbItemModel(title, link, isActive));

    return this;
  }
}
