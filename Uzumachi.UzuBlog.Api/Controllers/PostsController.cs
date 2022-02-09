using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Domain.Types;

namespace Uzumachi.UzuBlog.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase {

  private readonly IPostService _postService;
  private readonly ICategoryService _categoryService;

  public PostsController(IPostService postService, ICategoryService categoryService) {
    _postService = postService;
    _categoryService = categoryService;
  }

  [HttpGet("/posts")]
  public async Task<IActionResult> ListAsync([FromQuery] PostListRequest req) {
    var postsReponse = await _postService.GetListAsync(req);

    return Ok(postsReponse);
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

  [HttpGet("/posts/getById/{id}")]
  public async Task<ActionResult<PostDto>> GetByIdAsync(int id) {
    var post = await _postService.GetByIdAsync(id);

    return Ok(post);
  }
}
