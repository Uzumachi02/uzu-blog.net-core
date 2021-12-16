namespace Uzumachi.UzuBlog.Domain.Requests;

public class PostListRequest {

  public int UserId { get; set; }

  public int CategoryId { get; set; }

  public int LanguageId { get; set; }

  public int Limit { get; set; }

  public int Offset { get; set; }

  public string? Sorting { get; set; }
}
