using Mapster;
using Uzumachi.UzuBlog.Data.Filters;
using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;
using Uzumachi.UzuBlog.Domain.Requests;

namespace Uzumachi.UzuBlog.Core;

public class MappingRegister : ICodeGenerationRegister {

  public void Register(CodeGenerationConfig config) {
    config.AdaptFrom(nameof(UserEntity))
        .ForType<UserEntity>()
        .ForType<UserDto>();

    config.AdaptFrom(nameof(PostEntity))
        .ForType<PostEntity>()
        .ForType<PostDto>();

    config.AdaptFrom(nameof(PostListRequest))
       .ForType<PostListRequest>()
       .ForType<PostFilters>();

    config.AdaptFrom(nameof(PageEntity))
        .ForType<PageEntity>()
        .ForType<PageDto>();

    config.AdaptFrom(nameof(SeoEntity))
        .ForType<SeoEntity>()
        .ForType<SeoDto>();

    config.AdaptFrom(nameof(CategoryEntity))
        .ForType<CategoryEntity>()
        .ForType<CategoryDto>();

    config.AdaptFrom(nameof(TagEntity))
        .ForType<TagEntity>()
        .ForType<TagDto>();

    config.GenerateMapper("[name]Mapper")
        .ForType<UserDto>()
        .ForType<PostDto>()
        .ForType<PostFilters>()
        .ForType<PageDto>()
        .ForType<SeoDto>()
        .ForType<CategoryDto>()
        .ForType<TagDto>();
  }
}
