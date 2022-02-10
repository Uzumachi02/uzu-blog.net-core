using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Data.Models;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Core.Services;

public class PostService : IPostService {

  private readonly IUnitOfWork _unitOfWork;

  public PostService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<PostReponse> GetAsync(PostGetRequest req) {
    bool isEmptyAlias = string.IsNullOrWhiteSpace(req.Alias);

    if( req.Id == 0 && isEmptyAlias ) {
      throw new ArgumentException("Id or Alias not specific");
    }

    PostExtendentEntity? dbPost = null;
    PostIncludesModel includes = new() {
      IncludeUser = req.IncludeUser > 0,
      IncludeCategory = req.IncludeCategory > 0
    };

    if( req.Id > 0 ) {
      dbPost = await _unitOfWork.Posts.GetByIdWithIncludesAsync(req.Id, includes);
    } else if( !isEmptyAlias ) {
      dbPost = await _unitOfWork.Posts.GetByAliasWithIncludesAsync(req.Alias!, includes);
    }

    var postReponse = new PostReponse();

    if( dbPost is null ) {
      return postReponse;
    }

    postReponse.Item = dbPost.AdaptToPostDto();
    postReponse.User = dbPost.User.AdaptToUserDto();
    postReponse.Category = dbPost.Category.AdaptToCategoryDto();

    if( req.IncludeTags > 0 ) {
      postReponse.Tags = await GetTagsFromPosts(new[] { postReponse.Item });
    }

    if( req.IncludeComments > 0 ) {
      //TODO: IncludeComments
    }

    return postReponse;
  }

  public Task<PostReponse> GetByIdAsync(int id, PostGetRequest? req = null) {
    if( req is null ) {
      req = new();
    }

    req.Id = id;

    return GetAsync(req);
  }

  public Task<PostReponse> GetByAliasAsync(string alias, PostGetRequest? req = null) {
    if( req is null ) {
      req = new();
    }

    req.Alias = alias;

    return GetAsync(req);
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
      response.Users = await GetUsersFromPosts(posts);
    }

    if( req.IncludeCategories > 0 ) {
      response.Categories = await GetCategoriesFromPosts(posts);
    }

    if( req.IncludeTags > 0 ) {
      response.Tags = await GetTagsFromPosts(posts);
    }

    response.Items = posts;
    return response;
  }

  public async Task<int> IncrementViewsCountById(int postId, CancellationToken cancellationToken = default) {
    int newViewsCount = await _unitOfWork.Posts.IncrementViewsCountByIdAsync(postId, cancellationToken);

    return newViewsCount;
  }

  public async Task<IEnumerable<UserDto>?> GetUsersFromPosts(IEnumerable<PostDto> posts) {
    var usersId = posts.Select(p => p.UserId).Distinct();
    var dbUsers = await _unitOfWork.Users.GetListByIdsAsync(usersId);

    return dbUsers.Select(u => u.AdaptToUserDto());
  }

  public async Task<IEnumerable<CategoryDto>?> GetCategoriesFromPosts(IEnumerable<PostDto> posts) {
    var categoriesId = posts.Select(p => p.CategoryId).Distinct();
    var dbCategories = await _unitOfWork.Categories.GetListByIdsAsync(categoriesId);

    return dbCategories.Select(c => c.AdaptToCategoryDto());
  }

  public async Task<IEnumerable<TagDto>?> GetTagsFromPosts(IEnumerable<PostDto> posts) {
    HashSet<int> tagsId = new();

    foreach( var post in posts ) {
      if( post.TagIds != null ) {
        tagsId.UnionWith(post.TagIds);
      }
    }

    if( tagsId.Count > 0 ) {
      var dbTags = await _unitOfWork.Tags.GetListByIdsAsync(tagsId);

      return dbTags.Select(t => t.AdaptToTagDto());
    }

    return null;
  }
}
