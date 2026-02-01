using FEEE.Application.DTOs.User;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.User
{
    public static class UserMapper
    {
        public static UserModel ToModel(CreateUserRequest request) =>
            new()
            {
                Username = request.Username,
                Password = request.Password, // لاحقًا hashing
                Role = request.Role
            };

        public static void UpdateModel(UserModel model, UpdateUserRequest request)
        {
            model.Username = request.Username;
            model.Role = request.Role;
        }

        public static UserResponse ToResponse(UserModel model) =>
            new()
            {
                UserId = model.UserId,
                Username = model.Username,
                Role = model.Role
            };
    }

}
