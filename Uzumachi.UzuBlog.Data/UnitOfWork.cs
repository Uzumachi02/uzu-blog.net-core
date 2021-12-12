using System.Data;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Data.Repositories;

namespace Uzumachi.UzuBlog.Data;

public class UnitOfWork : IUnitOfWork {

  private readonly IDbConnection _dbConnection;

  #region Repository fields
  private ICategoryRepository? _categories;

  private ICommentRepository? _comments;

  private IImageRepository? _images;

  private IIpRepository? _ips;

  private IItemTypeRepository? _itemTypes;

  private ILanguageItemConnectionRepository? _languageItemConnections;

  private ILanguageRepository? _languages;

  private ILanguageResourceRepository? _languageResources;

  private ILikeRepository? _likes;

  private IMenuRepository? _menus;

  private IMenuTypeRepository? _menuTypes;

  private IPageRepository? _pages;

  private IPostRepository? _posts;

  private IPostTagRepository? _postTags;

  private ISeoRepository? _seos;

  private ITagRepository? _tags;

  private IUserAgentRepository? _userAgents;

  private IUserRepository? _users;
  #endregion

  #region Repository properties
  public ICategoryRepository Categories => _categories ??= new CategoryRepository(_dbConnection);

  public ICommentRepository Comments => _comments ??= new CommentRepository(_dbConnection);

  public IImageRepository Images => _images ??= new ImageRepository(_dbConnection);

  public IIpRepository Ips => _ips ??= new IpRepository(_dbConnection);

  public IItemTypeRepository ItemTypes => _itemTypes ??= new ItemTypeRepository(_dbConnection);

  public ILanguageItemConnectionRepository LanguageItemConnections => _languageItemConnections ??= new LanguageItemConnectionRepository(_dbConnection);

  public ILanguageRepository Languages => _languages ??= new LanguageRepository(_dbConnection);

  public ILanguageResourceRepository LanguageResources => _languageResources ??= new LanguageResourceRepository(_dbConnection);

  public ILikeRepository Likes => _likes ??= new LikeRepository(_dbConnection);

  public IMenuRepository Menus => _menus ??= new MenuRepository(_dbConnection);

  public IMenuTypeRepository MenuTypes => _menuTypes ??= new MenuTypeRepository(_dbConnection);

  public IPageRepository Pages => _pages ??= new PageRepository(_dbConnection);

  public IPostRepository Posts => _posts ??= new PostRepository(_dbConnection);

  public IPostTagRepository PostTags => _postTags ??= new PostTagRepository(_dbConnection);

  public ISeoRepository Seos => _seos ??= new SeoRepository(_dbConnection);

  public ITagRepository Tags => _tags ??= new TagRepository(_dbConnection);

  public IUserAgentRepository UserAgents => _userAgents ??= new UserAgentRepository(_dbConnection);

  public IUserRepository Users => _users ??= new UserRepository(_dbConnection);
  #endregion

  public UnitOfWork(IDbConnection dbConnection) {
    _dbConnection = dbConnection;
  }

  public IDbTransaction BeginTransaction() {
    if( _dbConnection.State != ConnectionState.Open ) {
      _dbConnection.Open();
    }

    return _dbConnection.BeginTransaction();
  }
}

