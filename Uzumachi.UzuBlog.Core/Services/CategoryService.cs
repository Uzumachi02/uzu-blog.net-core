using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;

namespace Uzumachi.UzuBlog.Core.Services;

public class CategoryService : ICategoryService {

  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;


}
