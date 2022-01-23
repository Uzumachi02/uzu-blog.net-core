using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class TagService : ITagService {

  private readonly IUnitOfWork _unitOfWork;

  public TagService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<TagDto?> GetByAliasAsync(string alias) {
    var dbTag = await _unitOfWork.Tags.GetByAliasAsync(alias);

    return dbTag.AdaptToTagDto();
  }
}
