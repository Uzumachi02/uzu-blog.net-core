namespace Uzumachi.UzuBlog.Domain.Responses;

public class ItemsResponse<T> {

  public int Count { get; set; }

  public IEnumerable<T>? Items { get; set; }
}
