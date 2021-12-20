using Uzumachi.UzuBlog.Domain.Dtos;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PostsViewModel : BaseViewModel {

  public List<PostDto> Posts { get; set; }

  public PostsViewModel(IEnumerable<PostDto> posts) {
    Title = "List of posts";
    Posts = posts.ToList();

    Breadcrumb.Add("Posts");
  }

  public PostsViewModel(CategoryDto category, IEnumerable<PostDto> posts) {
    Title = $"{category.Title} - List of posts";
    Posts = posts.ToList();

    Breadcrumb.Add("Posts", "/posts");
    Breadcrumb.Add(category.Title);
  }
}
