using System.Reflection;
using System.Text;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Converters;

public static class QueryStringConverter {

  public static string Serialize<T>(T obj) where T : class {
    StringBuilder query = ToQueryStringBuilder(obj);

    if( query.Length > 0 )
      query[0] = '?';

    return query.ToString();
  }

  private static StringBuilder ToQueryStringBuilder<T>(T obj, string prefix = "") where T : class {
    var gatherer = new StringBuilder();

    foreach( var p in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance) ) {
      var value = p.GetValue(obj, Array.Empty<object>());

      if( value != null ) {
        if( p.PropertyType.IsArray && value.GetType() == typeof(DateTime[]) )
          foreach( var item in (DateTime[])value )
            gatherer.Append($"&{prefix}{p.Name}={item:yyyy-MM-dd}");

        else if( p.PropertyType.IsArray )
          foreach( var item in (Array)value )
            gatherer.Append($"&{prefix}{p.Name}={item}");

        else if( p.PropertyType == typeof(string) )
          gatherer.Append($"&{prefix}{p.Name}={value}");

        else if( p.PropertyType == typeof(DateTime) && !value.Equals(Activator.CreateInstance(p.PropertyType)) ) // is not default
          gatherer.Append($"&{prefix}{p.Name}={(DateTime)value:yyyy-MM-dd}");

        else if( p.PropertyType.IsValueType && !value.Equals(Activator.CreateInstance(p.PropertyType)) ) // is not default
          gatherer.Append($"&{prefix}{p.Name}={value}");

        else if( p.PropertyType.IsClass )
          gatherer.Append(ToQueryStringBuilder(value, $"{prefix}{p.Name}."));
      }
    }

    return gatherer;
  }
}
