namespace Uzumachi.UzuBlog.Domain.Requests;

public class ListRequest {

  private int _offset;

  public int Page { get; set; }

  public int Limit { get; set; } = 20;

  public int Offset {
    get {
      if( Page > 1 ) {
        return Limit * (Page - 1);
      }

      return _offset;
    }

    set {
      _offset = value;
    }
  }

  public string? Sorting { get; set; }
}
