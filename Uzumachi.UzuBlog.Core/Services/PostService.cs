using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Services;

public class PostService : IPostService {

  private readonly IUnitOfWork _unitOfWork;

  public PostService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<PostDto?> GetByAliasAsync(string alias) {
    var dbPost = await _unitOfWork.Posts.GetByAliasAsync(alias);

    return dbPost.AdaptToPostDto();
  }

  public async Task<ItemsResponse<PostDto>> GetListAsync(PostListRequest req) {
    var filters = req.AdaptToPostFilters();
    var countPosts = await _unitOfWork.Posts.GetListCountAsync(filters);

    var response = new ItemsResponse<PostDto> {
      Count = countPosts
    };

    if( countPosts == 0 ) {
      response.Items = Array.Empty<PostDto>();

      return response;
    }

    var dbPosts = await _unitOfWork.Posts.GetListAsync(filters);
    var posts = dbPosts.Select(x => x.AdaptToPostDto()).ToArray();

    response.Items = posts;
    return response;
  }

  public async Task<int> IncrementViewsCountById(int postId, CancellationToken cancellationToken = default) {
    int newViewsCount = await _unitOfWork.Posts.IncrementViewsCountByIdAsync(postId, cancellationToken);

    return newViewsCount;
  }
}

