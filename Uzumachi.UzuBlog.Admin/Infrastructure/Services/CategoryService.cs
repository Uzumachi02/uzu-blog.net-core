using System.Net.Http.Json;
using Uzumachi.UzuBlog.Admin.Infrastructure.Converters;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Services;

public class CategoryService : ICategoryService {

  private readonly HttpClient _http;

  public CategoryService(HttpClient http) => _http = http;

  public async Task<CategoriesReponse> GetListAsync(CategoryListRequest req) {
    var url = "categories" + QueryStringConverter.Serialize(req);

    var categoriesReponse = await _http.GetFromJsonAsync<CategoriesReponse>(url)
      ?? new();

    return categoriesReponse;
  }
}
