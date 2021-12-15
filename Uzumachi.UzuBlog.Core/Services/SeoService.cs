using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class SeoService : ISeoService {

  private readonly IUnitOfWork _unitOfWork;

  public SeoService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<SeoDto?> GetByUrlAsync(string url) {
    var seoDb = await _unitOfWork.Seos.GetByUrlAsync(url);

    return seoDb.AdaptToSeoDto();
  }
}
