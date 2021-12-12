using System.Data;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface ILanguageItemConnectionRepository {

  Task<LanguageItemConnectionEntity> GetByIdAsync(int id);

  /// <returns>Id of new item.</returns>
  Task<int> CreateAsync(LanguageItemConnectionEntity languageitemconnection, CancellationToken token, IDbTransaction? transaction = null);
}
