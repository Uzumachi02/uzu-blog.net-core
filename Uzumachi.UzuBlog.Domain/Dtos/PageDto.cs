namespace Uzumachi.UzuBlog.Domain.Dtos;

public class PageDto {

  public int Id { get; set; }

  public int UserId { get; set; }

  public int LanguageId { get; set; }

  public string Alias { get; set; }

  public string Title { get; set; }

  public string Content { get; set; }

  public int ViewCount { get; set; }

  public int Status { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}