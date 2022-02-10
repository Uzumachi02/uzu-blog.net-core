using System.ComponentModel.DataAnnotations;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.FormModels;

public class PostFormModel {

  public int Id { get; set; }

  public int UserId { get; set; }

  [Required]
  public int CategoryId { get; set; }

  [Required]
  public int LanguageId { get; set; }

  [Required]
  public string Alias { get; set; }

  [Required]
  public string Title { get; set; }

  [Required, MinLength(10)]
  public string Excerpt { get; set; }

  [Required, MinLength(10)]
  public string Content { get; set; }

  public string Image { get; set; }

  public int[]? TagIds { get; set; }

  public bool CloseComments { get; set; }

  public int Status { get; set; }

  public DateTime PublishDate { get; set; }
}
