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

  public async Task<PostsReponse> GetListAsync(PostListRequest req) {
    var filters = req.AdaptToPostFilters();
    var countPosts = await _unitOfWork.Posts.GetListCountAsync(filters);

    var response = new PostsReponse {
      Count = countPosts
    };

    if( countPosts == 0 ) {
      response.Items = Array.Empty<PostDto>();

      return response;
    }

    var dbPosts = await _unitOfWork.Posts.GetListAsync(filters);
    var posts = dbPosts.Select(x => x.AdaptToPostDto()).ToArray();

    if( req.IncludeUsers > 0 ) {
      var usersId = posts.Select(p => p.UserId).Distinct();
      var dbUsers = await _unitOfWork.Users.GetListByIdsAsync(usersId);

      response.Users = dbUsers.Select(u => u.AdaptToUserDto());
    }

    if( req.IncludeCategories > 0 ) {
      var categoriesId = posts.Select(p => p.CategoryId).Distinct();
      var dbCategories = await _unitOfWork.Categories.GetListByIdsAsync(categoriesId);

      response.Categories = dbCategories.Select(c => c.AdaptToCategoryDto());
    }

    response.Items = posts;
    return response;
  }

  public async Task<int> IncrementViewsCountById(int postId, CancellationToken cancellationToken = default) {
    int newViewsCount = await _unitOfWork.Posts.IncrementViewsCountByIdAsync(postId, cancellationToken);

    return newViewsCount;
  }
}

