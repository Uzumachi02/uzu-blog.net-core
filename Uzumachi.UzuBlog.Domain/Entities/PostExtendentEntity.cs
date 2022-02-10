namespace Uzumachi.UzuBlog.Domain.Entities;

public class PostExtendentEntity : PostEntity {

  public UserEntity? User { get; set; }

  public CategoryEntity? Category { get; set; }
}
