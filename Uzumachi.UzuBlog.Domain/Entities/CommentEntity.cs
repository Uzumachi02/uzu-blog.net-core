namespace Uzumachi.UzuBlog.Domain.Entities;

public class CommentEntity {

  public const string TABLE = "public.comments";

  public int Id { get; set; }

  public int ParentId { get; set; }

  public int UserId { get; set; }

  public int ItemTypeId { get; set; }

  public int ItemId { get; set; }

  public int ReplyId { get; set; }

  public int ReplyUserId { get; set; }

  public string Text { get; set; }

  public int LikeCount { get; set; }

  public int ReplyCount { get; set; }

  public bool IsBanned { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}
