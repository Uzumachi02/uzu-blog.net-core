using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class CategoryDtoMapper
    {
        public static CategoryDto AdaptToCategoryDto(this CategoryEntity p1)
        {
            return p1 == null ? null : new CategoryDto()
            {
                Id = p1.Id,
                ParentId = p1.ParentId,
                LanguageId = p1.LanguageId,
                ItemTypeId = p1.ItemTypeId,
                Alias = p1.Alias,
                Title = p1.Title,
                DisplayOrder = p1.DisplayOrder,
                PostCount = p1.PostCount,
                Status = p1.Status,
                IsDeleted = p1.IsDeleted,
                CreateDate = p1.CreateDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static CategoryDto AdaptTo(this CategoryEntity p2, CategoryDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CategoryDto result = p3 ?? new CategoryDto();
            
            result.Id = p2.Id;
            result.ParentId = p2.ParentId;
            result.LanguageId = p2.LanguageId;
            result.ItemTypeId = p2.ItemTypeId;
            result.Alias = p2.Alias;
            result.Title = p2.Title;
            result.DisplayOrder = p2.DisplayOrder;
            result.PostCount = p2.PostCount;
            result.Status = p2.Status;
            result.IsDeleted = p2.IsDeleted;
            result.CreateDate = p2.CreateDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}