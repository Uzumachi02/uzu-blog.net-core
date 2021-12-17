using System.Text;
using System.Text.Json;
using Uzumachi.UzuBlog.Parsers.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Uzumachi.UzuBlog.Parsers;

public class PoindMdParser {

  private readonly string _url = "https://point.md/graphql";

  private PoindMdModel.Payload _payload;

  private readonly HttpClient _httpClient;

  public PoindMdParser() {
    _httpClient = new();

    _payload = new() {
      operationName = "NewsList",
      variables = new() {
        lang = "ru",
        visible = false,
        take = 30,
        with_count = true,
        projectId = "5107de83-f208-4ca4-87ed-9b69d58d16e1",
        url = "/"
      },
      query = @"query NewsList($projectId: String!, $url: String, $lang: String = ""ru"", $keyword: String, $visible: Boolean = true, $postedDateFrom: Int, $postedDateTo: Int, $take: Int = 30, $skip: Int, $sort: String, $with_count: Boolean = false, $token: String) {
        contents(
          project_id: $projectId
          url: $url
          lang: $lang
          keyword: $keyword
          visible: $visible
          posted_date_from: $postedDateFrom
          posted_date_to: $postedDateTo
          take: $take
          skip: $skip
          sort: $sort
          token: $token
        ) {
          id
          title {
            short
            long
            __typename
          }
          url
          description {
            long
            intro
            __typename
          }
          thumbnail
          tags
          cparent {
            id
            title {
              ru
              __typename
            }
            url {
              ru
              __typename
            }
            type
            __typename
          }
          pollId: poll_id
          __typename
        }
        count: contentsCount(
          project_id: $projectId
          lang: $lang
          keyword: $keyword
          url: $url
          visible: $visible
          posted_date_from: $postedDateFrom
          posted_date_to: $postedDateTo
        ) @include(if: $with_count)
      }"
    };
  }

  public async Task<PoindMdModel?> Run(CancellationToken cancellationToken) {
    var payload = JsonSerializer.Serialize(_payload);

    var todoItemJson = new StringContent(
      payload,
      Encoding.UTF8,
      Application.Json
    );

    using var httpResponseMessage =
      await _httpClient.PostAsync(_url, todoItemJson, cancellationToken);

    httpResponseMessage.EnsureSuccessStatusCode();

    using var contentStream =
      await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);

    var result = await JsonSerializer.DeserializeAsync<PoindMdModel>(contentStream, cancellationToken: cancellationToken);

    return result;
  }
}
