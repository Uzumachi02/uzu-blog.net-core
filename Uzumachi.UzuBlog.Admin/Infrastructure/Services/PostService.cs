using System.Net.Http.Json;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Services;

public class PostService : IPostService {

  private readonly HttpClient _http;

  public PostService(HttpClient http) {
    _http = http;
  }

  public async Task<PostsReponse> GetListAsync(PostListRequest req) {
    var postsReponse = await _http.GetFromJsonAsync<PostsReponse>("posts")
      ?? new();

    return postsReponse;
  }
}
