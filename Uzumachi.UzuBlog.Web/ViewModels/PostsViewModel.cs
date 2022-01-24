using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;
using Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PostsViewModel : BaseViewModel {

  public IEnumerable<PostDto>? Posts { get; set; }


  public static PostsViewModel CreateByPostsReponse(PostsReponse postsReponse) {
    PostsViewModel result = new();

    result.Posts = postsReponse.GroupingItems();

    return result;
  }
}
