namespace Uzumachi.UzuBlog.Domain.Entities;

public class MenuEntity : IEntity {

  public const string TABLE = "public.menus";

  public int Id { get; set; }

  public int ParentId { get; set; }

  public int UserId { get; set; }

  public int MenuTypeId { get; set; }

  public int LanguageId { get; set; }

  public int ItemTypeId { get; set; }

  public int ItemId { get; set; }

  public string Alias { get; set; }

  public string Title { get; set; }

  public string Url { get; set; }

  public int DisplayOrder { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}
