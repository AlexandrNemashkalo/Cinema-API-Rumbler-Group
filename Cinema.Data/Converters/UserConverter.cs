using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Data.Converters
{
    public static class UserConverter
    {

        public static UserDto Convert(User item)
        {
            return new UserDto
            {
                Email = item.Email,
                Id = item.Id,
                Name = item.Name       
            };
        }

        public static User Convert(UserDto item)
        {
            return new User
            {
                Id = item.Id,
                Email = item.Email,
                Name = item.Name,
                UserName = item.Email,
            };
        }
        public static List<UserDto> Convert(List<User> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<User> Convert(List<UserDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
        public static void Convert(User item, UserDto itemDto)
        {
            item.Name = itemDto.Name;
        }
    }
}
