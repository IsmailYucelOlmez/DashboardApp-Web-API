using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class UserMapperscs
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Password = userModel.Password,
                Email = userModel.Email,
                Phone = userModel.Phone,
                Uimage = userModel.Uimage,
                RoleId = userModel.RoleId,

            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Uimage = userDto.Uimage,
                RoleId = userDto.RoleId,

            };
        }
    }
}
