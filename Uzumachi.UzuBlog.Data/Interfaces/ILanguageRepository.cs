using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ILanguageRepository {

  Task<LanguageEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(LanguageEntity language, CancellationToken token, IDbTransaction? transaction = null);
}
