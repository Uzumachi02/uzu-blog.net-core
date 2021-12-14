using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class PageDtoMapper
    {
        public static PageDto AdaptToPageDto(this PageEntity p1)
        {
            return p1 == null ? null : new PageDto()
            {
                Id = p1.Id,
                UserId = p1.UserId,
                LanguageId = p1.LanguageId,
                Alias = p1.Alias,
                Title = p1.Title,
                Content = p1.Content,
                ViewCount = p1.ViewCount,
                Status = p1.Status,
                IsDeleted = p1.IsDeleted,
                CreateDate = p1.CreateDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static PageDto AdaptTo(this PageEntity p2, PageDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PageDto result = p3 ?? new PageDto();
            
            result.Id = p2.Id;
            result.UserId = p2.UserId;
            result.LanguageId = p2.LanguageId;
            result.Alias = p2.Alias;
            result.Title = p2.Title;
            result.Content = p2.Content;
            result.ViewCount = p2.ViewCount;
            result.Status = p2.Status;
            result.IsDeleted = p2.IsDeleted;
            result.CreateDate = p2.CreateDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}