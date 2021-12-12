using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IUserServices {

  public Task<UserDto> GetByIdAsync(int id);
}

