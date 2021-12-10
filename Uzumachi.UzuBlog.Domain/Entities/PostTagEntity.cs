namespace Uzumachi.UzuBlog.Domain.Entities;

public class PostTagEntity {

  public const string TABLE = "public.post_tags";

  public int Id { get; set; }

  public int PostId { get; set; }

  public int TagId { get; set; }
}

