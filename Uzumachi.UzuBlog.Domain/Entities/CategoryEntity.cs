namespace Uzumachi.UzuBlog.Domain.Entities;

public class CategoryEntity : IEntity {

  public const string TABLE = "public.categories";

  public int Id { get; set; }

  public int ParentId { get; set; }

  public int LanguageId { get; set; }

  public int ItemTypeId { get; set; }

  public string Alias { get; set; }

  public string Title { get; set; }

  public int PostCount { get; set; }

  public int Status { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}

