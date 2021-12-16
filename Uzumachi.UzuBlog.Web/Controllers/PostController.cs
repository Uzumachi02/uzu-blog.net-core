using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Web.Controllers;

[Route("Posts")]
public class PostController : Controller {

  private readonly IPostService _postService;

  public PostController(IPostService postService) {
    _postService = postService;
  }

  // GET: PostController
  [HttpGet]
  public async Task<IActionResult> List([FromQuery] PostListRequest req) {
    var posts = await _postService.GetListAsync(req);

    return Ok(posts);
  }

  // GET: PostController/Details/5
  public ActionResult Details(int id) {
    return View();
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
