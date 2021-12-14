using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class PostService : IPostService {

  private readonly IUnitOfWork _unitOfWork;

  public PostService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public Task<IEnumerable<PostDto>> GetListAsync() {
    List<PostDto> posts = new();


    return Task.FromResult<IEnumerable<PostDto>>(posts);
  }
}

