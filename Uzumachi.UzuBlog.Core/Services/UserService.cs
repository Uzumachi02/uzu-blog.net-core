using Uzumachi.UzuBlog.Core.Mappers;
using Uzumachi.UzuBlog.Core.Interfaces;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Services;

public class UserService : IUserService {

  private readonly IUnitOfWork _unitOfWork;

  public UserService(IUnitOfWork unitOfWork) =>
    _unitOfWork = unitOfWork;

  public async Task<UserDto> GetByIdAsync(int id) {
    var dbUser = await _unitOfWork.Users.GetByIdAsync(id)
        ?? throw new Exception("Comment");

    return dbUser.AdaptToUserDto();
  }

  public async Task<UserDto?> GetByUsernameAsync(string username) {
    var dbUser = await _unitOfWork.Users.GetByUsernameAsync(username);

    return dbUser.AdaptToUserDto();
  }
}
