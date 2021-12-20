using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Responses;

namespace Uzumachi.UzuBlog.Web.ViewModels;

public class PostsViewModel : BaseViewModel {

  public IEnumerable<PostDto>? Posts { get; set; }


  public static PostsViewModel CreateByPostsReponse(PostsReponse postsReponse) {
    PostsViewModel result = new();

    if( postsReponse.Items is null || !postsReponse.Items.Any() ) {
      return result;
    }

    Dictionary<int, UserDto>? groupUsers = null;
    Dictionary<int, CategoryDto>? groupCaregories = null;
    Dictionary<int, TagDto>? groupTags = null;
    bool eachPosts = false;

    if( postsReponse.Users != null && postsReponse.Users.Any() ) {
      groupUsers = postsReponse.Users.ToDictionary(x => x.Id, x => x);
      eachPosts = true;
    }

    if( postsReponse.Categories != null && postsReponse.Categories.Any() ) {
      groupCaregories = postsReponse.Categories.ToDictionary(x => x.Id, x => x);
      eachPosts = true;
    }

    if( postsReponse.Tags != null && postsReponse.Tags.Any() ) {
      groupTags = postsReponse.Tags.ToDictionary(x => x.Id, x => x);
      eachPosts = true;
    }

    if( eachPosts ) {
      bool hasUsers = groupUsers != null;
      bool hasCaregories = groupCaregories != null;
      bool hasTags = groupTags != null;

      foreach( var item in postsReponse.Items ) {
        if( hasUsers && groupUsers!.ContainsKey(item.UserId) ) {
          item.User = groupUsers[item.UserId];
        }

        if( hasCaregories && groupCaregories!.ContainsKey(item.CategoryId) ) {
          item.Category = groupCaregories[item.CategoryId];
        }

        if( hasTags && item.TagIds != null && item.TagIds.Length > 0 ) {
          List<TagDto> _tags = new();

          foreach( var tagId in item.TagIds ) {
            if( groupTags!.ContainsKey(tagId) ) {
              _tags.Add(groupTags[tagId]);
            }
          }

          item.Tags = _tags;
        }
      }
    }

    result.Posts = postsReponse.Items;

    return result;
  }
}
