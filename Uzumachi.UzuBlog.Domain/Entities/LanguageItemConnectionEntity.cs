namespace Uzumachi.UzuBlog.Domain.Entities;

public class LanguageItemConnectionEntity {

  public const string TABLE = "public.language_items_connections";

  public int Id { get; set; }

  public int LanguageId { get; set; }

  public int ItemTypeId { get; set; }

  public int BaseItemId { get; set; }

  public int SecondItemId { get; set; }

  public DateTime CreateDate { get; set; }
}

