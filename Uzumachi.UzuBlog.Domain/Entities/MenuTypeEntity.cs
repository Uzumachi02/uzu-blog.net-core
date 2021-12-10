namespace Uzumachi.UzuBlog.Domain.Entities;

public class MenuTypeEntity {

  public const string TABLE = "public.menu_types";

  public int Id { get; set; }

  public string Name { get; set; }

  public DateTime CreateDate { get; set; }
}
