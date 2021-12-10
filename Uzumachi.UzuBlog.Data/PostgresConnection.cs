using Npgsql;
using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;

namespace Uzumachi.UzuBlog.Data;

public class PostgresConnection : ISqlConnection {

  private readonly IDbConnection _db;

  public IDbConnection DB => _db;

  public PostgresConnection(string connectionString) {
    _db = new NpgsqlConnection(connectionString);
    _db.Open();
  }

  public void Dispose() {
    _db.Close();
    _db.Dispose();
  }
}

