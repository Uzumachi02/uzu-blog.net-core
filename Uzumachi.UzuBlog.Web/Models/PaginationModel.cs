namespace Uzumachi.UzuBlog.Web.Models;

public class PaginationModel {

  private const string LabelPrevious = "Previous page";
  private const string LabelNext = "Next page";
  private const string LabelDelimiter= "...";

  private List<PaginationButtonModel>? _buttons;

  public int ButtonsCount { get; set; }

  public int CurrentPage { get; set; }

  public int TotalPages { get; set; }

  public List<PaginationButtonModel> Buttons => _buttons ??= GetButtons();

  public bool HasButtons => Buttons.Any();

  public PaginationModel(int currentPage, int pageSize, int totalCount) {
    if( pageSize < 1 )
      pageSize = 20;

    ButtonsCount = 5;
    CurrentPage = currentPage > 0 ? currentPage : 1;
    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
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
    return button.Value > 1 ? "?page=" + button.Value : "#";
  }
}
