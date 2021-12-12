namespace Uzumachi.UzuBlog.Domain.Entities;

public class ImageEntity : IEntity {

  public const string TABLE = "public.images";

  public int Id { get; set; }

  public int UserId { get; set; }

  public string Name { get; set; }

  public string RelativePath { get; set; }

  public string AbsolutePath { get; set; }

  public string Hash { get; set; }

  public int Width { get; set; }

  public int Height { get; set; }

  public int Size { get; set; }

  public int Status { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}
