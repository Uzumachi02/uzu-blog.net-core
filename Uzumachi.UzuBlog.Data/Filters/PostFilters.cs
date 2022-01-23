using Dapper;
using Uzumachi.UzuBlog.Data.Helpers;

namespace Uzumachi.UzuBlog.Data.Filters;

public class PostFilters : BaseFilters {

  public int UserId { get; set; }

  public int CategoryId { get; set; }

  public int LanguageId { get; set; }

  public List<int>? TagIds { get; set; }

  public override string GetWhereSql(DynamicParameters parameters, bool needAND = false) {
    var wheres = new List<string>();

    if( UserId > 0 ) {
      wheres.Add("base.user_id = @userId");
      parameters.Add("userId", UserId);
    }

    if( CategoryId > 0 ) {
      wheres.Add("base.category_id = @categoryId");
      parameters.Add("categoryId", CategoryId);
    }

    if( LanguageId > 0 ) {
      wheres.Add("base.language_id = @languageId");
      parameters.Add("languageId", LanguageId);
    }

    if( TagIds != null && TagIds.Count > 0 ) {
      wheres.Add("base.tag_ids && @tag_ids");
      parameters.Add("tag_ids", TagIds.ToArray());
    }

    return SqlHelpers.WheresToSql(wheres, needAND);
  }
}
