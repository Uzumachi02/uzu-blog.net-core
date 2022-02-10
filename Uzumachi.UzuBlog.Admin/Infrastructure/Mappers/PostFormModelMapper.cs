using Uzumachi.UzuBlog.Admin.Infrastructure.FormModels;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Mappers;

public static partial class PostFormModelMapper {

  public static PostFormModel AdaptToPostFormModel(this PostDto p1) {
    return new PostFormModel {
      Id = p1.Id,
      UserId = p1.UserId,
      CategoryId = p1.CategoryId,
      LanguageId = p1.LanguageId,
      Alias = p1.Alias,
      Title = p1.Title,
      Excerpt = p1.Excerpt,
      Content = p1.Content,
      Image = p1.Image,
      TagIds = p1.TagIds,
      CloseComments = p1.CloseComments,
      Status = p1.Status,
      PublishDate = p1.PublishDate
    };
  }
}
