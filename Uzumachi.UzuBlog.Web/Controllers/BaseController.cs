using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Web.ViewModels;

namespace Uzumachi.UzuBlog.Web.Controllers;

public class BaseController : Controller {

  protected readonly ISeoService _seoService;

  public BaseController(ISeoService seoService) {
    _seoService = seoService;
  }

  public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
    var resultContext = await next();

    if( resultContext.Result is ViewResult view && view.Model is BaseViewModel baseViewModel ) {
      var url = Request.Path.ToString();
      var seo = await _seoService.GetByUrlAsync(url);

      if( seo is not null ) {
        baseViewModel.SetSeo(seo);
      }
    }
  }
}
