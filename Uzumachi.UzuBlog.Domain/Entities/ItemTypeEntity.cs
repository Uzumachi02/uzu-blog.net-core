namespace Uzumachi.UzuBlog.Domain.Entities;

public class ItemTypeEntity {

  public const string TABLE = "public.item_types";

  public int Id { get; set; }

  public string Name { get; set; }

  public DateTime CreateDate { get; set; }
}
