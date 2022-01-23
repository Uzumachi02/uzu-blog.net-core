using System.Collections.Generic;
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
                TagIds = funcMain1(p1.TagIds),
                Limit = p1.Limit,
                Offset = p1.Offset,
                Sorting = p1.Sorting
            };
        }
        public static PostFilters AdaptTo(this PostListRequest p3, PostFilters p4)
        {
            if (p3 == null)
            {
                return null;
            }
            PostFilters result = p4 ?? new PostFilters();
            
            result.UserId = p3.UserId;
            result.CategoryId = p3.CategoryId;
            result.LanguageId = p3.LanguageId;
            result.TagIds = funcMain2(p3.TagIds, result.TagIds);
            result.Limit = p3.Limit;
            result.Offset = p3.Offset;
            result.Sorting = p3.Sorting;
            return result;
            
        }
        
        private static List<int> funcMain1(List<int> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<int> result = new List<int>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                int item = p2[i];
                result.Add(item);
                i++;
            }
            return result;
            
        }
        
        private static List<int> funcMain2(List<int> p5, List<int> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<int> result = new List<int>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                int item = p5[i];
                result.Add(item);
                i++;
            }
            return result;
            
        }
    }
}