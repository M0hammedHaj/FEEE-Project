using FEEE.Application.DTOs.User;
using FEEE.Application.Mappings.User;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.User.GetAllUsers
{
    public class GetAllUsersService
    {
        private readonly IUserRepository _repository;

        public GetAllUsersService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserResponse>> ExecuteAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(UserMapper.ToResponse).ToList();
        }
    }

}
