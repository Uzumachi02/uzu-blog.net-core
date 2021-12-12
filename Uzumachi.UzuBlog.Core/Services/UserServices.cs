using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Services;

public class UserServices : IUserServices {

  private readonly IUnitOfWork _unitOfWork;

  public UserServices(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<UserEntity> GetByIdAsync(int id) {
    var dbUser = await _unitOfWork.Users.GetByIdAsync(id)
        ?? throw new Exception("Comment");

    return dbUser;
  }
}

