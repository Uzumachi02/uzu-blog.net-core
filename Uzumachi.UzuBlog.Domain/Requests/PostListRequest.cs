namespace Uzumachi.UzuBlog.Domain.Requests;

public class PostListRequest {

  public int UserId { get; set; }

  public int CategoryId { get; set; }

  public int LanguageId { get; set; }

  public int Limit { get; set; }

  public int Offset { get; set; }

  public string? Sorting { get; set; }

  public int IncludeUsers { get; set; }

  public int IncludeCategories { get; set; }

  public int IncludeTags { get; set; }

  public int IncludeComments { get; set; }
}
