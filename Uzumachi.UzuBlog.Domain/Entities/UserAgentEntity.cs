namespace Uzumachi.UzuBlog.Domain.Entities;

public class UserAgentEntity {

  public const string TABLE = "public.user_agents";

  public int Id { get; set; }

  public string UserAgent { get; set; }

  public string Details { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}
