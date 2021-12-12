namespace Uzumachi.UzuBlog.Domain.Entities;

public class LanguageResourceEntity : IEntity {

  public const string TABLE = "public.language_resources";

  public int Id { get; set; }

  public int LanguageId { get; set; }

  public string Key { get; set; }

  public string Value { get; set; }

  public string Comment { get; set; }

  public DateTime CreateDate { get; set; }
}

