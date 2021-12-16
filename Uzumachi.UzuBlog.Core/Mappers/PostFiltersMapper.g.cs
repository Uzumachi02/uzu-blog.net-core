using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class PostFiltersMapper
    {
        public static PostFilters AdaptToPostFilters(this PostListRequest p1)
        {
            return p1 == null ? null : new PostFilters()
            {
                UserId = p1.UserId,
                CategoryId = p1.CategoryId,
                LanguageId = p1.LanguageId,
                Limit = p1.Limit,
                Offset = p1.Offset,
                Sorting = p1.Sorting
            };
        }
        public static PostFilters AdaptTo(this PostListRequest p2, PostFilters p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PostFilters result = p3 ?? new PostFilters();
            
            result.UserId = p2.UserId;
            result.CategoryId = p2.CategoryId;
            result.LanguageId = p2.LanguageId;
            result.Limit = p2.Limit;
            result.Offset = p2.Offset;
            result.Sorting = p2.Sorting;
            return result;
            
        }
    }
}