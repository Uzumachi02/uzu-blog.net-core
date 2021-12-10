﻿namespace Uzumachi.UzuBlog.Domain.Entities;

public class TagEntity {

  public const string TABLE = "public.tags";

  public int Id { get; set; }

  public int LanguageId { get; set; }

  public string Alias { get; set; }

  public string Title { get; set; }

  public int PostCount { get; set; }

  public int Status { get; set; }

  public bool IsDeleted { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}
