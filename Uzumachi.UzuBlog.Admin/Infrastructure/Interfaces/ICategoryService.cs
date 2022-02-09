using Uzumachi.UzuBlog.Domain.Requests;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Admin.Infrastructure.Interfaces;

public interface ICategoryService {

  Task<CategoriesReponse> GetListAsync(CategoryListRequest req);
}
