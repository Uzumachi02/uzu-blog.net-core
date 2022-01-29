using Dapper;
using Uzumachi.UzuBlog.Data.Helpers;

namespace Uzumachi.UzuBlog.Data.Filters;

public class CategoryFilters : BaseFilters {

  public int UserId { get; set; }

  public int LanguageId { get; set; }

  public int ItemTypeId { get; set; }

  public int IncludeChildren { get; set; }

  public CategoryFilters() {
    DefaultSorting = "by-title-asc";
  }

  public override string GetWhereSql(DynamicParameters parameters, bool needAND = false) {
    var wheres = new List<string>();

    if( IncludeChildren == 0 ) {
      wheres.Add("base.parent_id = 0");
    }

    if( UserId > 0 ) {
      wheres.Add("base.user_id = @userId");
      parameters.Add("userId", UserId);
    }

    if( LanguageId > 0 ) {
      wheres.Add("base.language_id = @languageId");
      parameters.Add("languageId", LanguageId);
    }

    if( ItemTypeId > 0 ) {
      wheres.Add("base.item_type_id = @itemTypeId");
      parameters.Add("itemTypeId", ItemTypeId);
    }

    return SqlHelpers.WheresToSql(wheres, needAND);
  }
}
