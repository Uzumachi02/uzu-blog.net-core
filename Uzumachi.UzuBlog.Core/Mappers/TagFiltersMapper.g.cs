using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class TagFiltersMapper
    {
        public static TagFilters AdaptToTagFilters(this TagListRequest p1)
        {
            return p1 == null ? null : new TagFilters()
            {
                LanguageId = p1.LanguageId,
                Limit = p1.Limit,
                Offset = p1.Offset,
                Sorting = p1.Sorting
            };
        }
        public static TagFilters AdaptTo(this TagListRequest p2, TagFilters p3)
        {
            if (p2 == null)
            {
                return null;
            }
            TagFilters result = p3 ?? new TagFilters();
            
            result.LanguageId = p2.LanguageId;
            result.Limit = p2.Limit;
            result.Offset = p2.Offset;
            result.Sorting = p2.Sorting;
            return result;
            
        }
    }
}