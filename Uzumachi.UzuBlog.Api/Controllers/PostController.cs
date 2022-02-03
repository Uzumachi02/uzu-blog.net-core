using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Domain.Types;

namespace Uzumachi.UzuBlog.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {

  private readonly IPostService _postService;
  private readonly ICategoryService _categoryService;

  public PostController(IPostService postService, ICategoryService categoryService) {
    _postService = postService;
    _categoryService = categoryService;
  }

  [HttpGet("/posts")]
  public async Task<IActionResult> ListAsync([FromQuery] PostListRequest req) {
    var postsReponse = await _postService.GetListAsync(req);

    return Ok(postsReponse);
  }

  [HttpGet("/posts/categories")]
  public async Task<IActionResult> CategoriesListAsync([FromQuery] CategoryListRequest req) {
    req.ItemTypeId = ItemTypes.Post;
    req.IncludePosts = 1;
    req.IncludeChildren = 1;
    req.PostsLimit = 3;
    req.Limit = 5;

    var categoriesReponse = await _categoryService.GetListAsync(req);

    if( categoriesReponse.Posts != null && categoriesReponse.Posts.Any() ) {
      var postsReponse = new PostsReponse {
        Items = categoriesReponse.Posts.ToList(),
        Count = categoriesReponse.Posts.Count()
      };

      postsReponse.Categories = await _postService.GetCategoriesFromPosts(categoriesReponse.Posts);
      postsReponse.Users = await _postService.GetUsersFromPosts(categoriesReponse.Posts);
      postsReponse.Tags = await _postService.GetTagsFromPosts(categoriesReponse.Posts);
    }

    return Ok(categoriesReponse);
  }

  [HttpGet("/posts/{alias}")]
  public async Task<IActionResult> CategoryAsync(string alias, [FromQuery] PostListRequest req) {
    var category = await _categoryService.GetByAliasAsync(alias);

    if( category is null ) {
      return NotFound();
    }

    req.CategoryId = category.Id;

    var postsReponse = await _postService.GetListAsync(req);

    if( postsReponse.Items != null && postsReponse.Items.Any() ) {
      foreach( var item in postsReponse.Items ) {
        item.Category = category;
      }
    }

    return Ok(postsReponse);
  }


  [HttpGet("{catAlias}/{alias}")]
  public async Task<IActionResult> DetailsAsync(string catAlias, string alias) {
    var category = await _categoryService.GetByAliasAsync(catAlias);

    if( category is null ) {
      return NotFound();
    }

    var post = await _postService.GetByAliasAsync(alias);

    if( post is null ) {
      return NotFound();
    }

    post.Category = category;

    return Ok(post);
  }
}
