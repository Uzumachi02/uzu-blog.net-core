using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Interfaces;

public interface IUserServices {

  public Task<UserEntity> GetByIdAsync(int id);
}

