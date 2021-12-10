namespace Uzumachi.UzuBlog.Domain.Entities;

public class PostEntity {

  public const string TABLE = "public.posts";

  public int Id { get; set; }

  public int UserId { get; set; }

  public int CategoryId { get; set; }

  public int LanguageId { get; set; }

  public int ImageId { get; set; }

  public string Alias { get; set; }

  public string Title { get; set; }

  public string Excerpt { get; set; }

  public string Content { get; set; }

  public string Image { get; set; }

  public int TagCount { get; set; }

  public int ViewCount { get; set; }

  public int LikeCount { get; set; }

  public int CommentCount { get; set; }

  public bool CloseComments { get; set; }

  public int Status { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime PublishDate { get; set; }

  public DateTime UpdateDate { get; set; }
}

