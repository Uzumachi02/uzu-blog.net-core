namespace Uzumachi.UzuBlog.Web.Models;

public class PaginationModel {

  private const string LabelPrevious = "«";
  private const string LabelNext = "»";
  private const string LabelLast = "»»";
  private const string LabelFirst = "««";

  public int GroupIndex { get; set; }

  public int MinPage { get; set; }

  public int MaxPage { get; set; }

  public int NextPage { get; set; }

  public int PreviousPage { get; set; }

  public int TotalPages { get; set; }

  public int PageIndex { get; set; }

  public List<PaginationButtonModel> Buttons { get; set; }

  public bool HasButtons => Buttons.Any();

  public PaginationModel(int pageIndex, int pageSize, int totalCount, int pagesInGroup = 10) {

    if( pageSize < 1 )
      pageSize = 20;

    PageIndex = pageIndex;
    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    GroupIndex = (int)Math.Floor(Convert.ToDecimal(PageIndex) / Convert.ToDecimal(pagesInGroup));
    MinPage = GroupIndex * pagesInGroup + 1;
    MaxPage = MinPage + pagesInGroup - 1;
    PreviousPage = MinPage - 1;
    NextPage = MaxPage + 1;

    if( MinPage <= 1 ) {
      PreviousPage = 1;
    }

    if( MaxPage > TotalPages ) {
      MaxPage = TotalPages;
    }

    if( NextPage > TotalPages ) {
      NextPage = 0;
    }

    Buttons = GetButtons();
  }

  public List<PaginationButtonModel> GetButtons() {
    List<PaginationButtonModel> btns = new();

    var firstAndPrev = PreviousPages();
    btns.AddRange(firstAndPrev);

    var pages = GetNumberPages();
    btns.AddRange(pages);

    var nextAndLast = NextPages();
    btns.AddRange(nextAndLast);

    return btns;
  }

  private IEnumerable<PaginationButtonModel> PreviousPages() {
    yield return PageIndex == 0
        ? new PaginationButtonModel(LabelFirst, 1, isDisabled: true)
        : new PaginationButtonModel(LabelFirst, 1);

    yield return PreviousPage > 1
        ? new PaginationButtonModel(LabelPrevious, MinPage - 1)
        : new PaginationButtonModel(LabelPrevious, MinPage - 1, isDisabled: true);
  }

  private IEnumerable<PaginationButtonModel> GetNumberPages() {
    for( var i = MinPage; i <= MaxPage; i++ ) {
      if( i == PageIndex + 1 ) {
        yield return new PaginationButtonModel(i.ToString(), i, true);
        continue;
      }
      yield return new PaginationButtonModel(i.ToString(), i);
    }
  }

  private IEnumerable<PaginationButtonModel> NextPages() {
    yield return NextPage >= MaxPage
        ? new PaginationButtonModel(LabelNext, MaxPage + 1)
        : new PaginationButtonModel(LabelNext, MaxPage, isDisabled: true);

    yield return PageIndex + 1 == TotalPages
        ? new PaginationButtonModel(LabelLast, TotalPages, isDisabled: true)
        : new PaginationButtonModel(LabelLast, TotalPages);
  }
}
