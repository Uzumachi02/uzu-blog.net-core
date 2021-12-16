namespace Uzumachi.UzuBlog.Web.Models;

public class OpenGraphProtocolModel {

  public Dictionary<string, string> Items { get; set; }

  public OpenGraphProtocolModel(Dictionary<string, string>? storage = null) {
    Items = storage ?? new();
  }

  public OpenGraphProtocolModel(string title, string type, string image, string url) {
    Items = new() {
      { "og:title", title },
      { "og:type", type },
      { "og:image", image },
      { "og:url", url }
    };
  }

  public OpenGraphProtocolModel SetTitle(string title) {
    Items["og:title"] = title;

    return this;
  }

  public OpenGraphProtocolModel SetType(string type) {
    Items["og:type"] = type;

    return this;
  }

  public OpenGraphProtocolModel SetImage(string image) {
    Items["og:image"] = image;

    return this;
  }

  public OpenGraphProtocolModel SetUrl(string url) {
    Items["og:url"] = url;

    return this;
  }

  public OpenGraphProtocolModel AddMetadata(string name, string value) {
    Items[name] = value;

    return this;
  }
}
