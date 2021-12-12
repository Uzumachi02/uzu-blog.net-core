using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ILanguageResourceRepository {

  Task<LanguageResourceEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(LanguageResourceEntity languageresource, CancellationToken token, IDbTransaction? transaction = null);
}
