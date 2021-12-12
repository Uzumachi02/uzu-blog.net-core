using Microsoft.Extensions.DependencyInjection;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Core.Services;

namespace Uzumachi.UzuBlog.Core;

public static class DependencyInjection {

  public static IServiceCollection ConfigureCore(this IServiceCollection services) {

    // injection services
    services.AddScoped<IUserServices, UserServices>();

    return services;
  }
}

