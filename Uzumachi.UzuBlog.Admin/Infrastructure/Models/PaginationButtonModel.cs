namespace Uzumachi.UzuBlog.Admin.Infrastructure.Models;

public class PaginationButtonModel {

  public string Title { get; private set; }

  public int Value { get; private set; }

  public bool IsActive { get; private set; }

  public bool IsDisabled { get; private set; }

  public PaginationButtonModel(string title, int value, bool isActive = false, bool isDisabled = false) {
    Title = title;
    Value = value;
    IsActive = isActive;
    IsDisabled = isDisabled;
  }
}
