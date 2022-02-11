namespace Uzumachi.UzuBlog.Admin.Infrastructure.Models;

public class TreeSelectItemModel {

  public int Id { get; set; }

  public int ParentId { get; set; }

  public string Title { get; set; } = string.Empty;

  public bool IsSelected { get; set; }

  public IEnumerable<TreeSelectItemModel>? Children { get; set; }
}
