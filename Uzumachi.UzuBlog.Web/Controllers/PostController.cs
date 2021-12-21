using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Web.Models;
using Uzumachi.UzuBlog.Web.ViewModels;

namespace Uzumachi.UzuBlog.Web.Controllers;

[Route("Posts")]
public class PostController : Controller {

  private readonly IPostService _postService;
  private readonly ICategoryService _categoryService;

  public PostController(IPostService postService, ICategoryService categoryService) {
    _postService = postService;
    _categoryService = categoryService;
  }

  // GET: PostController
  [HttpGet]
  public async Task<IActionResult> ListAsync([FromQuery] PostListRequest req) {
    req.IncludeCategories = req.IncludeUsers = req.IncludeTags = 1;

    var postsReponse = await _postService.GetListAsync(req);
    var vm = PostsViewModel.CreateByPostsReponse(postsReponse);

    vm.Title = "List of posts";
    vm.Breadcrumb.Add("Posts");

    vm.Pagination = new(req.Page, req.Limit, postsReponse.Count);

    return View(vm);
  }

  [HttpGet("{alias}")]
  public async Task<IActionResult> CategoryAsync(string alias, [FromQuery] PostListRequest req) {
    var category = await _categoryService.GetByAliasAsync(alias);

    if( category is null ) {
      return NotFound();
    }

    req.CategoryId = category.Id;
    req.IncludeUsers = req.IncludeTags = 1;

    var postsReponse = await _postService.GetListAsync(req);

    if( postsReponse.Items != null && postsReponse.Items.Any() ) {
      foreach( var item in postsReponse.Items ) {
        item.Category = category;
      }
    }

    var vm = PostsViewModel.CreateByPostsReponse(postsReponse);

    vm.Title = $"{category.Title} - List of posts";
    vm.Breadcrumb
      .Add("Posts", "/posts")
      .Add(category.Title);

    return View(vm);
  }

  // GET: PostController/Details/5
  [HttpGet("{catAlias}/{alias}")]
  public async Task<IActionResult> DetailsAsync(string catAlias, string alias, CancellationToken cancellationToken) {
    var category = await _categoryService.GetByAliasAsync(catAlias);

    if( category is null ) {
      return NotFound();
    }

    var post = await _postService.GetByAliasAsync(alias);

    if( post is null ) {
      return NotFound();
    }

    post.Category = category;
    post.ViewCount = await _postService.IncrementViewsCountById(post.Id, cancellationToken);

    PostViewModel vm = new(post);

    return View(vm);
  }

  // GET: PostController/Create
  public ActionResult Create() {
    return View();
  }

  // POST: PostController/Create
  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Create(IFormCollection collection) {
    try {
      return RedirectToAction(nameof(Index));
    } catch {
      return View();
    }
  }

  // GET: PostController/Edit/5
  public ActionResult Edit(int id) {
    return View();
  }

  // POST: PostController/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Edit(int id, IFormCollection collection) {
    try {
      return RedirectToAction(nameof(Index));
    } catch {
      return View();
    }
  }

  // GET: PostController/Delete/5
  public ActionResult Delete(int id) {
    return View();
  }

  // POST: PostController/Delete/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Delete(int id, IFormCollection collection) {
    try {
      return RedirectToAction(nameof(Index));
    } catch {
      return View();
    }
  }
}
