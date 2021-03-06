using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Web.Infrastructure.Builders;
using Uzumachi.UzuBlog.Web.ViewModels;
using Uzumachi.UzuBlog.Web.Infrastructure.Extensions;
using Uzumachi.UzuBlog.Domain.Types;

namespace Uzumachi.UzuBlog.Web.Controllers;

[Route("[controller]")]
public class PostController : Controller {

  private readonly IPostService _postService;
  private readonly ICategoryService _categoryService;

  public PostController(IPostService postService, ICategoryService categoryService) {
    _postService = postService;
    _categoryService = categoryService;
  }

  // GET: PostController
  [HttpGet("/posts")]
  public async Task<IActionResult> ListAsync([FromQuery] PostListRequest req) {
    req.IncludeCategories = req.IncludeUsers = req.IncludeTags = 1;

    var postsReponse = await _postService.GetListAsync(req);
    var vm = PostsViewModel.CreateByPostsReponse(postsReponse);

    vm.Title = "List of posts";
    vm.Breadcrumb.Add("Posts");

    vm.Pagination = new PaginationBuilder().BuildByRequest(Request, postsReponse.Count);

    return View(vm);
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

      categoriesReponse.Posts = postsReponse.GroupingItems();
    }

    var vm = PostsCategoriesViewModel.CreateByCategoriesReponse(categoriesReponse);

    vm.Title = "List of posts categories";
    vm.Breadcrumb
      .Add("Posts", LinkBuilder.Post.List())
      .Add("Categories");

    vm.Pagination = new PaginationBuilder()
      .SetPageSize(req.Limit)
      .BuildByRequest(Request, categoriesReponse.Count);

    return View(vm);
  }

  [HttpGet("/posts/{alias}")]
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
      .Add("Posts", LinkBuilder.Post.List())
      .Add(category.Title);

    vm.Pagination = new PaginationBuilder().BuildByRequest(Request, postsReponse.Count);

    return View(vm);
  }

  // GET: PostController/Details/5
  [HttpGet("{catAlias}/{alias}")]
  public async Task<IActionResult> DetailsAsync(string catAlias, string alias, CancellationToken cancellationToken) {
    var category = await _categoryService.GetByAliasAsync(catAlias);

    if( category is null ) {
      return NotFound();
    }

    var postResponse = await _postService.GetByAliasAsync(alias);

    if( postResponse.Item is null ) {
      return NotFound();
    }

    postResponse.Item.Category = category;
    postResponse.Item.ViewCount = await _postService.IncrementViewsCountById(postResponse.Item.Id, cancellationToken);

    PostViewModel vm = new(postResponse.Item);

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
