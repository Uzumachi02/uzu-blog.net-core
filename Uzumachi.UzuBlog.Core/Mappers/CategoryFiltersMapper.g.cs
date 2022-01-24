using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class CategoryFiltersMapper
    {
        public static CategoryFilters AdaptToCategoryFilters(this CategoryListRequest p1)
        {
            return p1 == null ? null : new CategoryFilters()
            {
                UserId = p1.UserId,
                LanguageId = p1.LanguageId,
                IncludeChildren = p1.IncludeChildren,
                Limit = p1.Limit,
                Offset = p1.Offset,
                Sorting = p1.Sorting
            };
        }
        public static CategoryFilters AdaptTo(this CategoryListRequest p2, CategoryFilters p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CategoryFilters result = p3 ?? new CategoryFilters();
            
            result.UserId = p2.UserId;
            result.LanguageId = p2.LanguageId;
            result.IncludeChildren = p2.IncludeChildren;
            result.Limit = p2.Limit;
            result.Offset = p2.Offset;
            result.Sorting = p2.Sorting;
            return result;
            
        }
    }
}