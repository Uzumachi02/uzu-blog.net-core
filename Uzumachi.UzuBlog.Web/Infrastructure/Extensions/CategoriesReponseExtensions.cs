using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Web.Infrastructure.Extensions;

public static class CategoriesReponseExtensions {

  public static IEnumerable<CategoryDto>? GroupingItems(this CategoriesReponse categoriesReponse) {
    if( categoriesReponse.Items is null || !categoriesReponse.Items.Any() ) {
      return categoriesReponse.Items;
    }

    Dictionary<int, List<PostDto>>? groupPosts = null;
    bool eachPosts = false;

    if( categoriesReponse.Posts != null && categoriesReponse.Posts.Any() ) {
      groupPosts = new();

      foreach( var post in categoriesReponse.Posts ) {
        if( !groupPosts.ContainsKey(post.CategoryId) ) {
          groupPosts[post.CategoryId] = new();
        }

        groupPosts[post.CategoryId].Add(post);
      }

      eachPosts = true;
    }

    if( eachPosts ) {
      bool hasPosts = groupPosts != null;

      foreach( var item in categoriesReponse.Items ) {
        if( hasPosts && groupPosts!.ContainsKey(item.Id) ) {
          item.Posts = groupPosts[item.Id];
        }
      }
    }

    return categoriesReponse.Items;
  }
}
