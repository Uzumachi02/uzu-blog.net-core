using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class TagDtoMapper
    {
        public static TagDto AdaptToTagDto(this TagEntity p1)
        {
            return p1 == null ? null : new TagDto()
            {
                Id = p1.Id,
                LanguageId = p1.LanguageId,
                Alias = p1.Alias,
                Title = p1.Title,
                PostCount = p1.PostCount,
                Status = p1.Status,
                IsDeleted = p1.IsDeleted,
                CreateDate = p1.CreateDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static TagDto AdaptTo(this TagEntity p2, TagDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            TagDto result = p3 ?? new TagDto();
            
            result.Id = p2.Id;
            result.LanguageId = p2.LanguageId;
            result.Alias = p2.Alias;
            result.Title = p2.Title;
            result.PostCount = p2.PostCount;
            result.Status = p2.Status;
            result.IsDeleted = p2.IsDeleted;
            result.CreateDate = p2.CreateDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}