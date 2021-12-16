namespace Uzumachi.UzuBlog.Data.Helpers;

public static class SqlHelpers {

  public static string GetLimitExpression(int limit) {
    return limit > 0 ? " LIMIT " + limit : string.Empty;
  }

  public static string GetOffsetExpression(int offset) {
    return offset > 0 ? " OFFSET " + offset : string.Empty;
  }

  public static string GetLimitOffsetExpression(int limit, int offset) {
    return GetLimitExpression(limit) + GetOffsetExpression(offset);
  }

  public static string WheresToSql(List<string> wheres, bool needAND = false) {
    string sql = string.Empty;

    if( wheres.Count == 0 ) {
      if( !needAND ) {
        wheres.Add("(1 = 1)");
        sql = " ";
      }
    } else {
      if( needAND ) {
        sql += " AND ";
      } else {
        sql = " ";
      }
    }

    sql += string.Join(" AND ", wheres);

    return sql;
  }
}