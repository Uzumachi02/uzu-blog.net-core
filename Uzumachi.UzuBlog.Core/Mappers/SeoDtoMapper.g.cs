using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class SeoDtoMapper
    {
        public static SeoDto AdaptToSeoDto(this SeoEntity p1)
        {
            return p1 == null ? null : new SeoDto()
            {
                Id = p1.Id,
                UserId = p1.UserId,
                ItemTypeId = p1.ItemTypeId,
                ItemId = p1.ItemId,
                Url = p1.Url,
                Title = p1.Title,
                H1 = p1.H1,
                Description = p1.Description,
                Keywords = p1.Keywords,
                Others = p1.Others,
                CreateDate = p1.CreateDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static SeoDto AdaptTo(this SeoEntity p2, SeoDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SeoDto result = p3 ?? new SeoDto();
            
            result.Id = p2.Id;
            result.UserId = p2.UserId;
            result.ItemTypeId = p2.ItemTypeId;
            result.ItemId = p2.ItemId;
            result.Url = p2.Url;
            result.Title = p2.Title;
            result.H1 = p2.H1;
            result.Description = p2.Description;
            result.Keywords = p2.Keywords;
            result.Others = p2.Others;
            result.CreateDate = p2.CreateDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}