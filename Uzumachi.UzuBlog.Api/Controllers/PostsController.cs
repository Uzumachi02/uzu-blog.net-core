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

  [HttpGet]
  public async Task<IActionResult> ListAsync([FromQuery] PostListRequest req) {
    var postsReponse = await _postService.GetListAsync(req);

    return Ok(postsReponse);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<PostDto>> GetByIdAsync(int id, [FromQuery] PostGetRequest req) {
    req.Id = id;

    var response = await _postService.GetByIdAsync(id, req);

    if( response.Item is null ) {
      return NotFound();
    }

    return Ok(response);
  }

  [HttpGet("{alias}")]
  public async Task<ActionResult<PostDto>> GetByAliasAsync(string alias, [FromQuery] PostGetRequest req) {
    req.Alias = alias;

    var response = await _postService.GetAsync(req);

    if( response.Item is null ) {
      return NotFound();
    }

    return Ok(response);
  }
}
