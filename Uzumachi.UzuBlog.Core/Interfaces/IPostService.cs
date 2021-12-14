using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IPostService {

  public Task<IEnumerable<PostDto>> GetListAsync();
}

