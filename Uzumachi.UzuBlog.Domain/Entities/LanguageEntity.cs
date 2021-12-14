namespace Uzumachi.UzuBlog.Domain.Entities;

public class LanguageEntity : IEntity {

  public const string TABLE = "public.languages";

  public int Id { get; set; }

  public string CultureName { get; set; }

  public string DisplayName { get; set; }

  public string Country { get; set; }

  public string Region { get; set; }

  public string Icon { get; set; }

  public int DisplayOrder { get; set; }

  public bool IsDefault { get; set; }

  public DateTime CreateDate { get; set; }
}

