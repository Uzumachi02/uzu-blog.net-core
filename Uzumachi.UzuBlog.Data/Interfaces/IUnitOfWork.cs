using System.Data;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IUnitOfWork {

  IDbTransaction BeginTransaction();
}

