using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Web.Infrastructure.Builders;
using Uzumachi.UzuBlog.Web.ViewModels;

namespace Uzumachi.UzuBlog.Web.Controllers;

[Route("[controller]")]
public class TagController : Controller {

  private readonly ITagService _tagService;

  public TagController(ITagService tagService) {
    _tagService = tagService;
  }

  [HttpGet("/tags")]
  public async Task<IActionResult> ListAsync([FromQuery] TagListRequest req) {
    var tagsResponse = await _tagService.GetListAsync(req);
    var vm = TagsViewModel.CreateByTagsReponse(tagsResponse);

    vm.Pagination = new PaginationBuilder()
      .SetPageSize(req.Limit)
      .BuildByRequest(Request, tagsResponse.Count);

    return View(vm);
  }

  [HttpGet("{alias}")]
  public async Task<IActionResult> DetailsAsync(string alias, [FromQuery] PostListRequest req, [FromServices] IPostService postService) {
    var tag = await _tagService.GetByAliasAsync(alias);

    if( tag is null ) {
      return NotFound();
    }

    req.IncludeCategories = req.IncludeUsers = req.IncludeTags = 1;
    req.TagIds = new() { tag.Id };

    var postsReponse = await postService.GetListAsync(req);
    var vm = new TagViewModel(tag);

    vm.SetPostsFromPostsReponse(postsReponse);
    vm.Pagination = new PaginationBuilder().BuildByRequest(Request, postsReponse.Count);

    return View(vm);
  }
}
