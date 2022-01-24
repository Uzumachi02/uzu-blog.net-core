using Dapper;
using Uzumachi.UzuBlog.Data.Helpers;

namespace Uzumachi.UzuBlog.Data.Filters;

public class TagFilters : BaseFilters {

  public int LanguageId { get; set; }

  public TagFilters() {
    DefaultSorting = "by-title-asc";
  }

  public override string GetWhereSql(DynamicParameters parameters, bool needAND = false) {
    var wheres = new List<string>();

    if( LanguageId > 0 ) {
      wheres.Add("base.language_id = @languageId");
      parameters.Add("languageId", LanguageId);
    }

    return SqlHelpers.WheresToSql(wheres, needAND);
  }
}
