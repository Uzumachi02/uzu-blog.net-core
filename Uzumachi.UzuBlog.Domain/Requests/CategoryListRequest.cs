namespace Uzumachi.UzuBlog.Domain.Requests;

public class CategoryListRequest : ListRequest {

  public int UserId { get; set; }

  public int LanguageId { get; set; }

  public int ItemTypeId { get; set; }

  public int IncludeChildren { get; set; }

  public int IncludePosts { get; set; }

  public int PostsLimit { get; set; }
}
