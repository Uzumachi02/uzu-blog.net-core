using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Web.ViewModels;

namespace Uzumachi.UzuBlog.Web.Controllers;

public class PageController : Controller {

  private readonly ILogger<PageController> _logger;
  private readonly IPageService _pageService;

  public PageController(ILogger<PageController> logger, IPageService pageService) {
    _logger = logger;
    _pageService = pageService;
  }

  public IActionResult Index() {

    return View();
  }

  public async Task<IActionResult> Details(string alias) {
    var page = await _pageService.GetByAliasAsync(alias);

    if( page is null ) {
      return NotFound();
    }

    var vm = new PageViewModel {
      Title = page.Title,
      H1 = page.Title,
      Page = page
    };

    return View(vm);
  }
}
