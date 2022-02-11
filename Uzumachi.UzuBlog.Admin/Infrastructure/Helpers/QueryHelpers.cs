using Microsoft.Extensions.Primitives;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Helpers;

/// <summary>
/// Provides methods for parsing and manipulating query strings.
/// </summary>
public static class QueryHelpers {

  /// <summary>
  /// Append the given query key and value to the URI.
  /// </summary>
  /// <param name="uri">The base URI.</param>
  /// <param name="name">The name of the query key.</param>
  /// <param name="value">The query value.</param>
  /// <returns>The combined result.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
  /// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c>.</exception>
  /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
  public static string AddQueryString(string uri, string name, string value) {
    if( uri == null ) {
      throw new ArgumentNullException(nameof(uri));
    }

    if( name == null ) {
      throw new ArgumentNullException(nameof(name));
    }

    if( value == null ) {
      throw new ArgumentNullException(nameof(value));
    }

    return AddQueryString(
        uri, new[] { new KeyValuePair<string, string?>(name, value) });
  }

  /// <summary>
  /// Append the given query keys and values to the URI.
  /// </summary>
  /// <param name="uri">The base URI.</param>
  /// <param name="queryString">A dictionary of query keys and values to append.</param>
  /// <returns>The combined result.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
  /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
  public static string AddQueryString(string uri, IDictionary<string, string?> queryString) {
    if( uri == null ) {
      throw new ArgumentNullException(nameof(uri));
    }

    if( queryString == null ) {
      throw new ArgumentNullException(nameof(queryString));
    }

    return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string?>>)queryString);
  }

  /// <summary>
  /// Append the given query keys and values to the URI.
  /// </summary>
  /// <param name="uri">The base URI.</param>
  /// <param name="queryString">A collection of query names and values to append.</param>
  /// <returns>The combined result.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
  /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
  public static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, StringValues>> queryString) {
    if( uri == null ) {
      throw new ArgumentNullException(nameof(uri));
    }

    if( queryString == null ) {
      throw new ArgumentNullException(nameof(queryString));
    }

    return AddQueryString(uri, queryString.SelectMany(kvp => kvp.Value, (kvp, v) => KeyValuePair.Create<string, string?>(kvp.Key, v)));
  }

  /// <summary>
  /// Append the given query keys and values to the URI.
  /// </summary>
  /// <param name="uri">The base URI.</param>
  /// <param name="queryString">A collection of name value query pairs to append.</param>
  /// <returns>The combined result.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
  /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
  public static string AddQueryString(
      string uri,
      IEnumerable<KeyValuePair<string, string?>> queryString) {
    if( uri == null ) {
      throw new ArgumentNullException(nameof(uri));
    }

    if( queryString == null ) {
      throw new ArgumentNullException(nameof(queryString));
    }

    var anchorIndex = uri.IndexOf('#');
    var uriToBeAppended = uri;
    var anchorText = "";
    // If there is an anchor, then the query string must be inserted before its first occurrence.
    if( anchorIndex != -1 ) {
      anchorText = uri.Substring(anchorIndex);
      uriToBeAppended = uri.Substring(0, anchorIndex);
    }

    var queryIndex = uriToBeAppended.IndexOf('?');
    var hasQuery = queryIndex != -1;

    var sb = new StringBuilder();
    sb.Append(uriToBeAppended);
    foreach( var parameter in queryString ) {
      if( parameter.Value == null ) {
        continue;
      }

      sb.Append(hasQuery ? '&' : '?');
      sb.Append(UrlEncoder.Default.Encode(parameter.Key));
      sb.Append('=');
      sb.Append(UrlEncoder.Default.Encode(parameter.Value));
      hasQuery = true;
    }

    sb.Append(anchorText);
    return sb.ToString();
  }

  /// <summary>
  /// Parse a query string into its component key and value parts.
  /// </summary>
  /// <param name="queryString">The raw query string value, with or without the leading '?'.</param>
  /// <returns>A collection of parsed keys and values.</returns>
  public static Dictionary<string, StringValues> ParseQuery(string? queryString) {
    var result = ParseNullableQuery(queryString);

    if( result == null ) {
      return new Dictionary<string, StringValues>();
    }

    return result;
  }

  /// <summary>
  /// Parse a query string into its component key and value parts.
  /// </summary>
  /// <param name="queryString">The raw query string value, with or without the leading '?'.</param>
  /// <returns>A collection of parsed keys and values, null if there are no entries.</returns>
  public static Dictionary<string, StringValues>? ParseNullableQuery(string? queryString) {
    if( queryString is null ) {
      return null;
    }

    var result = new Dictionary<string, StringValues>();

    var queryStringCollection = HttpUtility.ParseQueryString(queryString);

    foreach( var key in queryStringCollection.AllKeys ) {
      if( key != null )
        result.Add(key, queryStringCollection[key]);
    }

    return result;
  }
}
