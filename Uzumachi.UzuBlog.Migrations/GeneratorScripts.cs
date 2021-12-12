using System.Reflection;
using Uzumachi.UzuBlog.Domain.Entities;
using System.Text;
using System.Text.RegularExpressions;

namespace Uzumachi.UzuBlog.Migrations;

public class GeneratorScripts {

  private Dictionary<string, string> ruleTypes = new() {
    { "Int32", "int4" },
    { "String", "varchar" },
    { "Boolean", "bool DEFAULT false" },
    { "DateTime", "timestamp" },
  };

  private DateTime lastFileDatetime;

  private readonly string solutionDirectory;

  private readonly string scriptDirectory;

  public GeneratorScripts() {
    var currentAssembly = Assembly.GetExecutingAssembly();
    solutionDirectory = GetSolutionRoot(currentAssembly);
    scriptDirectory = Path.Combine(solutionDirectory, "Scripts");

    lastFileDatetime = DateTime.Now;
  }

  public void Run() {
    var entityType = typeof(IEntity);
    var domainAssembly = Assembly.GetAssembly(entityType) ?? throw new Exception("Domain Assembly not found");
    var types = domainAssembly.GetTypes();
    var entityTypes = types.Where(t => t.GetInterfaces().Contains(entityType)).ToList();
    var existsScripts = GetExistsScripts();

    foreach( var type in entityTypes ) {
      try {
        var tableName = GetTableName(type);
        var scriptName = GetScriptName(tableName);

        if( existsScripts.Contains(scriptName) ) {
          continue;
        }

        var script = GenerateScript(type, tableName);

        SaveScriptToFile(script, scriptName);
      } catch( Exception ex ) {
        Console.WriteLine(ex);
      }
    }
  }

  private List<string> GetExistsScripts() {
    List<string> result = new();
    var files = Directory.GetFiles(scriptDirectory, "*.sql");

    foreach( var file in files ) {
      var fileName = Path.GetFileName(file);
      var scriptName = Regex.Replace(fileName, @"^\d+_", "").Replace(".sql", "");

      result.Add(scriptName);
    }

    return result;
  }

  private string GenerateScript(Type type, string tableName) {
    StringBuilder sb = new();
    sb.AppendFormat("CREATE TABLE IF NOT EXISTS {0} (", EscapeTableName(tableName));
    sb.AppendLine();

    var properties = type.GetProperties();

    foreach( var property in properties ) {
      sb.AppendLine(GetColumn(property));
    }

    sb.AppendLine("\tPRIMARY KEY (\"id\")");
    sb.AppendLine(");");

    return sb.ToString();
  }

  private string GetTableName(Type type) {
    var fieldTable = type.GetField("TABLE") ?? throw new MissingFieldException(nameof(type), "TABLE");
    return (string)fieldTable.GetRawConstantValue();
  }

  private string EscapeTableName(string tableName) {
    return string.Join('.', tableName.Split('.').Select(x => $"\"{x}\""));
  }

  private string GetColumn(PropertyInfo property) {
    if( property.Name.Equals("Id") ) {
      return "\t\"id\" serial4,";
    }

    if( property.Name.Equals("CreateDate") || property.Name.Equals("UpdateDate") ) {
      return string.Format("\t\"{0}\" timestamp DEFAULT now(),", GetColumnName(property));
    }

    return string.Format("\t\"{0}\" {1},", GetColumnName(property), GetColumnType(property));
  }

  private string GetColumnName(PropertyInfo property)
    => ToUnderscoreCase(property.Name);

  private string GetColumnType(PropertyInfo property)
    => ruleTypes.ContainsKey(property.PropertyType.Name)
      ? ruleTypes[property.PropertyType.Name]
      : "unknown";

  private string ToUnderscoreCase(string str) =>
        string.Concat(str.Select((x, i) => (i > 0 && char.IsUpper(x) && (char.IsLower(str[i - 1]) || char.IsLower(str[i + 1])))
            ? "_" + x.ToString() : x.ToString())).ToLower();

  private string GetScriptName(string tableName) {
    return string.Format("table_{0}_create", getFileNameByTable(tableName));
  }

  private void SaveScriptToFile(string script, string scriptName) {
    var fileName = string.Format("{0}_{1}.sql", getFileDate(), scriptName);

    File.WriteAllText(Path.Combine(scriptDirectory, fileName), script);
  }

  private string getFileNameByTable(string tableName) {
    return tableName.Split('.').Last();
  }

  private string getFileDate() {
    var nowDate = DateTime.Now;

     if( nowDate < lastFileDatetime || EqualsDate(nowDate, lastFileDatetime) ) {
      nowDate = lastFileDatetime.AddSeconds(1);
    }

    lastFileDatetime = nowDate;

    return nowDate.ToString("yyyyMMddHHmmss");
  }

  private string GetSolutionRoot(Assembly assembly) {
    return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, assembly.GetName().Name);
  }

  private bool EqualsDate(DateTime first, DateTime second)
    => first.Year.Equals(second.Year)
      && first.Month.Equals(second.Month)
      && first.Day.Equals(second.Day)
      && first.Hour.Equals(second.Hour)
      && first.Minute.Equals(second.Minute)
      && first.Second.Equals(second.Second);

  private void GenerateIRepository(Type type) {
    string nameEntity = type.Name.Replace("Entity", "");
    string className = $"I{nameEntity}Repository";
    string template = @"using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface {0} {{

  Task<{1}> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync({1} {2}, CancellationToken token, IDbTransaction? transaction = null);
}}
";

    string code = string.Format(template, className, type.Name, nameEntity.ToLower());
    var distFile = Path.Combine(Directory.GetParent(solutionDirectory).FullName, "Uzumachi.UzuBlog.Data", "Interfaces", $"{className}.cs");

    File.WriteAllText(distFile, code);
  }
}

