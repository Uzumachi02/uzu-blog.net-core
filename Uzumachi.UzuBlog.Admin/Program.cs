global using Uzumachi.UzuBlog.Admin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Uzumachi.UzuBlog.Admin;
using Uzumachi.UzuBlog.Admin.Infrastructure.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));

builder.Services.AddScoped(sp => new HttpClient {
  BaseAddress = new Uri(builder.Configuration.GetValue<string>("Services:Api"))
});

// dependency injection
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
