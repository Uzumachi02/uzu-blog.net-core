using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;

namespace Uzumachi.UzuBlog.Data;

public class UnitOfWork : IUnitOfWork {

  private readonly IDbConnection _dbConnection;

  public UnitOfWork(IDbConnection dbConnection) {
    _dbConnection = dbConnection;
  } 

  public IDbTransaction BeginTransaction() {
    if( _dbConnection.State != ConnectionState.Open ) {
      _dbConnection.Open();
    }

    return _dbConnection.BeginTransaction();
  }
}

