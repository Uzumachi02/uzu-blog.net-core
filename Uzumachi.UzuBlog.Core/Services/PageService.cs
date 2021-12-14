using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class PageService : IPageService {

  private readonly IUnitOfWork _unitOfWork;

  public PageService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;


  public async Task<PageDto?> GetByAliasAsync(string alias) {
    var page = await _unitOfWork.Pages.GetByAliasAsync(alias);

    return page.AdaptToPageDto();
  }
}
