using System;
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
                TagIds = funcMain1(p1.TagIds),
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
        public static PostDto AdaptTo(this PostEntity p3, PostDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            PostDto result = p4 ?? new PostDto();
            
            result.Id = p3.Id;
            result.UserId = p3.UserId;
            result.CategoryId = p3.CategoryId;
            result.LanguageId = p3.LanguageId;
            result.ImageId = p3.ImageId;
            result.Alias = p3.Alias;
            result.Title = p3.Title;
            result.Excerpt = p3.Excerpt;
            result.Content = p3.Content;
            result.Image = p3.Image;
            result.TagIds = funcMain2(p3.TagIds, result.TagIds);
            result.TagCount = p3.TagCount;
            result.ViewCount = p3.ViewCount;
            result.LikeCount = p3.LikeCount;
            result.CommentCount = p3.CommentCount;
            result.CloseComments = p3.CloseComments;
            result.Status = p3.Status;
            result.IsDeleted = p3.IsDeleted;
            result.CreateDate = p3.CreateDate;
            result.PublishDate = p3.PublishDate;
            result.UpdateDate = p3.UpdateDate;
            return result;
            
        }
        
        private static int[] funcMain1(int[] p2)
        {
            if (p2 == null)
            {
                return null;
            }
            int[] result = new int[p2.Length];
            Array.Copy(p2, 0, result, 0, p2.Length);
            return result;
            
        }
        
        private static int[] funcMain2(int[] p5, int[] p6)
        {
            if (p5 == null)
            {
                return null;
            }
            int[] result = new int[p5.Length];
            Array.Copy(p5, 0, result, 0, p5.Length);
            return result;
            
        }
    }
}