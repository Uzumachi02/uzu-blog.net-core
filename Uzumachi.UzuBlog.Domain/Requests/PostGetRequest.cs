namespace Uzumachi.UzuBlog.Domain.Requests;

public class PostGetRequest {

  public int Id { get; set; }

  public string? Alias { get; set; }

  public int IncludeUser { get; set; }

  public int IncludeCategory { get; set; }

  public int IncludeTags { get; set; }

  public int IncludeComments { get; set; }
}
