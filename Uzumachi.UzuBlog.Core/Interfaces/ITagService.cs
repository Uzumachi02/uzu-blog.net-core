using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface ITagService {

  Task<TagDto?> GetByAliasAsync(string alias);

  Task<TagsReponse> GetListAsync(TagListRequest req);
}
