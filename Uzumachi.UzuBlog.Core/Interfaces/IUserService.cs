using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IUserService {

  Task<UserDto?> GetByUsernameAsync(string username);
}
