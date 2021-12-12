namespace Uzumachi.UzuBlog.Domain.Entities;

public class LikeEntity : IEntity {

  public const string TABLE = "public.likes";

  public int Id { get; set; }

  public int UserId { get; set; }

  public int ItemTypeId { get; set; }

  public int ItemId { get; set; }

  public DateTime CreateDate { get; set; }
}
