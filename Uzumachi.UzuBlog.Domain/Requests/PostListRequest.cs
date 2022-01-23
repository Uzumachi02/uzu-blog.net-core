namespace Uzumachi.UzuBlog.Domain.Requests;

public class PostListRequest : ListRequest {

  public int UserId { get; set; }

  public int CategoryId { get; set; }

  public List<int>? TagIds { get; set; }

  public int LanguageId { get; set; }

  public int IncludeUsers { get; set; }

  public int IncludeCategories { get; set; }

  public int IncludeTags { get; set; }

  public int IncludeComments { get; set; }
}
