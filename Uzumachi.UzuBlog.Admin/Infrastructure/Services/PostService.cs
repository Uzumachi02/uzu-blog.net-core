using System.Net.Http.Json;
using Uzumachi.UzuBlog.Admin.Infrastructure.Converters;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Services;

public class PostService : IPostService {

  private readonly HttpClient _http;

  public PostService(HttpClient http) {
    _http = http;
  }

  public async Task<PostReponse> GetByIdAsync(int id, PostGetRequest? req = null) {
    var url = $"posts/{id}";

    if( req != null ) {
      url += QueryStringConverter.Serialize(req);
    }

    var postReponse = await _http.GetFromJsonAsync<PostReponse>(url) ?? new();

    return postReponse;
  }

  public async Task<PostsReponse> GetListAsync(PostListRequest req) {
    var postsReponse = await _http.GetFromJsonAsync<PostsReponse>("posts")
      ?? new();

    return postsReponse;
  }
}
