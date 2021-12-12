using System.Data;

namespace Uzumachi.UzuBlog.Data.Interfaces;

public interface IUnitOfWork {

  ICategoryRepository Categories { get; }

  ICommentRepository Comments { get; }

  IImageRepository Images { get; }

  IIpRepository Ips { get; }

  IItemTypeRepository ItemTypes { get; }

  ILanguageItemConnectionRepository LanguageItemConnections { get; }

  ILanguageRepository Languages { get; }

  ILanguageResourceRepository LanguageResources { get; }

  ILikeRepository Likes { get; }

  IMenuRepository Menus { get; }

  IMenuTypeRepository MenuTypes { get; }

  IPageRepository Pages { get; }

  IPostRepository Posts { get; }

  IPostTagRepository PostTags { get; }

  ISeoRepository Seos { get; }

  ITagRepository Tags { get; }

  IUserAgentRepository UserAgents { get; }

  IUserRepository Users { get; }

  IDbTransaction BeginTransaction();
}

