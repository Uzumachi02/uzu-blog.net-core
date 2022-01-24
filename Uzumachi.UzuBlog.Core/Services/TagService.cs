using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Services;

public class TagService : ITagService {

  private readonly IUnitOfWork _unitOfWork;

  public TagService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<TagDto?> GetByAliasAsync(string alias) {
    var dbTag = await _unitOfWork.Tags.GetByAliasAsync(alias);

    return dbTag.AdaptToTagDto();
  }

  public async Task<TagsReponse> GetListAsync(TagListRequest req) {
    var filters = req.AdaptToTagFilters();
    var countTags = await _unitOfWork.Tags.GetListCountAsync(filters);

    var response = new TagsReponse {
      Count = countTags
    };

    if( countTags == 0 ) {
      response.Items = Array.Empty<TagDto>();

      return response;
    }

    var dbTags = await _unitOfWork.Tags.GetListAsync(filters);
    var tags = dbTags.Select(x => x.AdaptToTagDto()).ToArray();

    response.Items = tags;
    return response;
  }
}
