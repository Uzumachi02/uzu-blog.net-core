using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Uzumachi.UzuBlog.Web.Parsers;

public class PoindMdParser {

  private readonly string _url = "https://point.md/graphql";

  private Payload _payload;

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

  public async Task<Result?> Run(CancellationToken cancellationToken) {
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

    var result = await JsonSerializer.DeserializeAsync<Result>(contentStream, cancellationToken: cancellationToken);

    return result;
  }

  public class Title {
    public string @short { get; set; }
    public string @long { get; set; }
    public string __typename { get; set; }
    public string ru { get; set; }
  }

  public class Description {
    public string @long { get; set; }
    public string intro { get; set; }
    public string __typename { get; set; }
  }

  public class Dates {
    public string posted { get; set; }
    public string postedWithYear { get; set; }
    public string postedSeparator { get; set; }
    public string postedDMYH { get; set; }
    public string postedTs { get; set; }
    public string postedH { get; set; }
    public string postedDM { get; set; }
    public string dateT { get; set; }
    public string __typename { get; set; }
  }

  public class Counters {
    public int comment { get; set; }
    public int view { get; set; }
    public int like { get; set; }
    public string __typename { get; set; }
  }

  public class Url {
    public string ru { get; set; }
    public string __typename { get; set; }
  }

  public class Cparent {
    public string id { get; set; }
    public Title title { get; set; }
    public Url url { get; set; }
    public string type { get; set; }
    public string __typename { get; set; }
  }

  public class Content {
    public string id { get; set; }
    public Title title { get; set; }
    public string url { get; set; }
    public Description description { get; set; }
    public Dates dates { get; set; }
    public Counters counters { get; set; }
    public string thumbnail { get; set; }
    public List<string> tags { get; set; }
    public Cparent cparent { get; set; }
    public string pollId { get; set; }
    public string __typename { get; set; }
  }

  public class Data {
    public List<Content> contents { get; set; }
    public int count { get; set; }
  }

  public class Location {
    public int line { get; set; }
    public int column { get; set; }
  }

  public class Error {
    public string message { get; set; }
    public List<Location> locations { get; set; }
  }

  public class Result {
    public Data data { get; set; }

    public List<Error> errors { get; set; }
  }

  public class PayloadVariables {
    public string lang { get; set; }
    public bool visible { get; set; }
    public int take { get; set; }
    public bool with_count { get; set; }
    public string projectId { get; set; }
    public string url { get; set; }
  }

  public class Payload {
    public string operationName { get; set; }
    public PayloadVariables variables { get; set; }
    public string query { get; set; }
  }
}
