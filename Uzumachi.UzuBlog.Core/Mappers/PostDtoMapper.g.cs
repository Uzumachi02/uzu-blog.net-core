using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class PostDtoMapper
    {
        public static PostDto AdaptToPostDto(this PostEntity p1)
        {
            return p1 == null ? null : new PostDto()
            {
                Id = p1.Id,
                UserId = p1.UserId,
                CategoryId = p1.CategoryId,
                LanguageId = p1.LanguageId,
                ImageId = p1.ImageId,
                Alias = p1.Alias,
                Title = p1.Title,
                Excerpt = p1.Excerpt,
                Content = p1.Content,
                Image = p1.Image,
                TagCount = p1.TagCount,
                ViewCount = p1.ViewCount,
                LikeCount = p1.LikeCount,
                CommentCount = p1.CommentCount,
                CloseComments = p1.CloseComments,
                Status = p1.Status,
                IsDeleted = p1.IsDeleted,
                CreateDate = p1.CreateDate,
                PublishDate = p1.PublishDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static PostDto AdaptTo(this PostEntity p2, PostDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PostDto result = p3 ?? new PostDto();
            
            result.Id = p2.Id;
            result.UserId = p2.UserId;
            result.CategoryId = p2.CategoryId;
            result.LanguageId = p2.LanguageId;
            result.ImageId = p2.ImageId;
            result.Alias = p2.Alias;
            result.Title = p2.Title;
            result.Excerpt = p2.Excerpt;
            result.Content = p2.Content;
            result.Image = p2.Image;
            result.TagCount = p2.TagCount;
            result.ViewCount = p2.ViewCount;
            result.LikeCount = p2.LikeCount;
            result.CommentCount = p2.CommentCount;
            result.CloseComments = p2.CloseComments;
            result.Status = p2.Status;
            result.IsDeleted = p2.IsDeleted;
            result.CreateDate = p2.CreateDate;
            result.PublishDate = p2.PublishDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}