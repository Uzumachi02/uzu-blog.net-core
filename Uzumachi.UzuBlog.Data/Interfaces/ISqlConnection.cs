using System.Data;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ISqlConnection : IDisposable {

  public IDbConnection DB { get; }
}

