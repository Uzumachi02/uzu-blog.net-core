using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IPageService {

  public Task<PageDto?> GetByAliasAsync(string alias);
}
