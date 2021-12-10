namespace Uzumachi.UzuBlog.Domain.Entities;

public class SeoEntity {

  public const string TABLE = "public.seo";

  public int Id { get; set; }

  public int UserId { get; set; }

  public int ItemTypeId { get; set; }

  public int ItemId { get; set; }

  public string Url { get; set; }

  public string Title { get; set; }

  public string H1 { get; set; }

  public string Description { get; set; }

  public string Keywords { get; set; }

  public string Others { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}

