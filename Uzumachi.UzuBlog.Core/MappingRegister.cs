using Mapster;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core;

public class MappingRegister : ICodeGenerationRegister {

  public void Register(CodeGenerationConfig config) {
    config.AdaptFrom(nameof(UserEntity))
        .ForType<UserEntity>()
        .ForType<UserDto>();

    config.AdaptFrom(nameof(PostEntity))
        .ForType<PostEntity>()
        .ForType<PostDto>();

    config.GenerateMapper("[name]Mapper")
        .ForType<UserDto>()
        .ForType<PostDto>();
  }
}

