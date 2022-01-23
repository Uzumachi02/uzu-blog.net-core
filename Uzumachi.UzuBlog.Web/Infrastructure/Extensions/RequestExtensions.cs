namespace Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

public static class RequestExtensions {

  public static Dictionary<string, string> GetRequestValues(this HttpRequest request) {
    return request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());
  }

  public static string TryGetQueryText(this HttpRequest request, string fieldName, string defaultValue = "") {
    if( request.Query.Count > 0 ) {
      if( request.Query.ContainsKey(fieldName) ) {
        return request.Query[fieldName].ToString();
      }
    }

    return defaultValue;
  }

  public static int TryGetQueryInt(this HttpRequest request, string fieldName, int defaultValue = 0) {
    if( request.Query.Count > 0 ) {
      if( request.Query.ContainsKey(fieldName) ) {
        if( int.TryParse(request.Query[fieldName].ToString(), out int res) ) {
          return res;
        }
      }
    }

    return defaultValue;
  }
}
