namespace Uzumachi.UzuBlog.Domain.Requests;

public class TagListRequest : ListRequest {

  public int LanguageId { get; set; }

  public TagListRequest() {
    Limit = 500;
  }
}
