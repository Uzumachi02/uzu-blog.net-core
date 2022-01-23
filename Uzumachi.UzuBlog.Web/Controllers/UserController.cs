using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Web.Infrastructure.Builders;

namespace Uzumachi.UzuBlog.Web.Controllers;

[Route("[controller]")]
public class UserController : Controller {

  private readonly IUserService _userService;

  public UserController(IUserService userService) {
    _userService = userService;
  }

  [HttpGet("{username}")]
  public async Task<IActionResult> DetailsAsync(string username, [FromServices] IPostService postService) {
    var user = await _userService.GetByUsernameAsync(username);

    if( user is null ) {
      return NotFound();
    }

    if( !username.Equals(user.Username) ) {
      // TODO: change to RedirectPermanent
      return Redirect(LinkBuilder.User.Details(user.Username));
    }

    var posts = await postService.GetListAsync(new Domain.Requests.PostListRequest{
      UserId = user.Id,
      Limit = 5
    });

    return Ok(new {
      user,
      posts
    });
  }
}

