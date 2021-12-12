using Uzumachi.UzuBlog.Domain.Dtos;
using Uzumachi.UzuBlog.Domain.Entities;

namespace Uzumachi.UzuBlog.Core.Mappers
{
    public static partial class UserDtoMapper
    {
        public static UserDto AdaptToUserDto(this UserEntity p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Id = p1.Id,
                LanguageId = p1.LanguageId,
                Username = p1.Username,
                Email = p1.Email,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Birthday = p1.Birthday,
                Avatar = p1.Avatar,
                IsAdmin = p1.IsAdmin,
                IsBanned = p1.IsBanned,
                IsDeleted = p1.IsDeleted,
                OnlineDate = p1.OnlineDate,
                CreateDate = p1.CreateDate,
                UpdateDate = p1.UpdateDate
            };
        }
        public static UserDto AdaptTo(this UserEntity p2, UserDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserDto result = p3 ?? new UserDto();
            
            result.Id = p2.Id;
            result.LanguageId = p2.LanguageId;
            result.Username = p2.Username;
            result.Email = p2.Email;
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Birthday = p2.Birthday;
            result.Avatar = p2.Avatar;
            result.IsAdmin = p2.IsAdmin;
            result.IsBanned = p2.IsBanned;
            result.IsDeleted = p2.IsDeleted;
            result.OnlineDate = p2.OnlineDate;
            result.CreateDate = p2.CreateDate;
            result.UpdateDate = p2.UpdateDate;
            return result;
            
        }
    }
}