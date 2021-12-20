using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface ICategoryService {

  Task<CategoryDto?> GetByAliasAsync(string alias);
}
