using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase {

  private readonly ICategoryService _categoryService;

  public CategoriesController(ICategoryService categoryService) =>
    _categoryService = categoryService;

  [HttpGet]
  public async Task<IActionResult> ListAsync([FromQuery] CategoryListRequest req) {
    var categoriesReponse = await _categoryService.GetListAsync(req);

    return Ok(categoriesReponse);
  }
}
