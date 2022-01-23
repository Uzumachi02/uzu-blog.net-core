using Microsoft.Extensions.DependencyInjection;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Services;

namespace Uzumachi.UzuBlog.Core;

public static class DependencyInjection {

  public static IServiceCollection ConfigureCore(this IServiceCollection services) {

    // injection services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IPostService, PostService>();
    services.AddScoped<IPageService, PageService>();
    services.AddScoped<ISeoService, SeoService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ITagService, TagService>();

    return services;
  }
}

