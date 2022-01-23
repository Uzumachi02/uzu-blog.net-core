using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Text;
using System.Text.RegularExpressions;

namespace Uzumachi.UzuBlog.Web.Models;

public class PaginationModel {

  private const string LabelPrevious = "Previous page";
  private const string LabelNext = "Next page";
  private const string LabelDelimiter= "...";
  private const string KeyPageFormat = "page={0}";

  private List<PaginationButtonModel>? _buttons;

  private string _urlFormat = string.Empty;

  public int ButtonsCount { get; set; }

  public int CurrentPage { get; set; }

  public int TotalPages { get; set; }

  public List<PaginationButtonModel> Buttons => _buttons ??= GetButtons();

  public bool HasButtons => Buttons.Any();

  public PaginationModel(int totalCount, int currentPage = 1, int pageSize = 20, string baseUrl = "", Dictionary<string, string>? requestValues = null) {
    if( totalCount < 1 ) {
      return;
    }

    if( pageSize < 1 )
      pageSize = 20;

    ButtonsCount = 5;
    CurrentPage = currentPage > 0 ? currentPage : 1;
    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

    InitUrl(baseUrl, requestValues);
  }

  public List<PaginationButtonModel> GetButtons() {
    bool needLastBtn = true;
    bool needDelimiterInStart = false;
    bool needDelimiterInEnd = false;
    bool existsPrev, existsNext;

    int previousPage, nextPage;
    int halfInterval = ButtonsCount / 2;
    int startIndex = CurrentPage - halfInterval;
    int endIndex = CurrentPage + halfInterval;

    if( TotalPages > ButtonsCount ) {
      if( startIndex > 2 ) {
        needDelimiterInStart = true;
      } else {
        startIndex = 2;
        endIndex = startIndex + ButtonsCount - 1;
      }

      if( endIndex < TotalPages - 1 ) {
        needDelimiterInEnd = true;
      } else {
        startIndex = TotalPages - ButtonsCount + 1;
        endIndex = TotalPages - 1;
      }
    } else {
      startIndex = 2;
      endIndex = TotalPages - 1;
      needLastBtn = (startIndex <= endIndex || TotalPages == 2);
    }

    if( CurrentPage == 1 ) {
      existsPrev = false;
      previousPage = CurrentPage;
    } else {
      existsPrev = true;
      previousPage = CurrentPage - 1;
    }

    if( CurrentPage >= TotalPages ) {
      existsNext = false;
      nextPage = CurrentPage;
    } else {
      existsNext = true;
      nextPage = CurrentPage + 1;
    }

    List<PaginationButtonModel> btns = new();

    btns.Add(new(LabelPrevious, previousPage, false, !existsPrev));
    btns.Add(new("1", 1, CurrentPage == 1));

    if( needDelimiterInStart ) {
      btns.Add(new(LabelDelimiter, -1, false, true));
    }

    for( int i = startIndex; i <= endIndex; i++ ) {
      btns.Add(new(i.ToString(), i, CurrentPage == i));
    }

    if( needDelimiterInEnd ) {
      btns.Add(new(LabelDelimiter, -1, false, true));
    }

    if( needLastBtn ) {
      btns.Add(new(TotalPages.ToString(), TotalPages, CurrentPage == TotalPages));
    }

    btns.Add(new(LabelNext, nextPage, false, !existsNext));

    return btns;
  }

  public string GetUrl(PaginationButtonModel button) {
    if( button.Value < 2 ) {
      return Regex.Replace(_urlFormat, @"page=\{0\}&?", "").TrimEnd('?');
    }

    return string.Format(_urlFormat, button.Value);
  }

  private void InitUrl(string baseUrl, Dictionary<string, string>? requestValues = null) {
    char querySymbol = '?';
    StringBuilder url = new();
    Dictionary<string, StringValues>? queries = null;

    if( baseUrl.Length == 0 ) {
      url.Append(querySymbol);
    } else {
      int queryIndex = baseUrl.IndexOf(querySymbol);

      if( queryIndex >= 0 ) {
        var baseUrlQueries = baseUrl[queryIndex..];
        baseUrl = baseUrl[..queryIndex];
        queries = QueryHelpers.ParseQuery(baseUrlQueries);
      }

      url.Append(baseUrl);
      url.Append(querySymbol);
    }

    if( requestValues != null ) {
      if( queries is null ) {
        queries = new();
      }

      foreach( var item in requestValues ) {
        queries[item.Key] = item.Value;
      }
    }

    url.Append(KeyPageFormat);

    if( queries != null && queries.Any() ) {
      queries.Remove("page");

      _urlFormat = QueryHelpers.AddQueryString(url.ToString(), queries);
    } else {
      _urlFormat = url.ToString();
    }
  }
}
