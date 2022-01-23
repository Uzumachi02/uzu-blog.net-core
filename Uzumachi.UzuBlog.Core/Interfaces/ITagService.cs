using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface ITagService {

  Task<TagDto?> GetByAliasAsync(string alias);
}
