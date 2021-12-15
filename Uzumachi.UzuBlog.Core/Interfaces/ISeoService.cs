using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface ISeoService {

  public Task<SeoDto?> GetByUrlAsync(string url);
}
