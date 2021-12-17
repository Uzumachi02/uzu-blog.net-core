namespace Uzumachi.UzuBlog.Parsers.Models;

public class PoindMdModel {
  public Data data { get; set; }
  public List<Error> errors { get; set; }

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
