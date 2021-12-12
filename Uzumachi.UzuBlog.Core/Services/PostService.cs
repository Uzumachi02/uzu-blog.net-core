using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;

namespace Uzumachi.UzuBlog.Core.Services;

public class PostService : IPostService {

  private readonly IUnitOfWork _unitOfWork;

  public PostService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;


}

