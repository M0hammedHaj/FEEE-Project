using FEEE.Application.DTOs.User;
using FEEE.Application.Mappings.User;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.User.GetUserById
{
    public class GetUserByIdService
    {
        private readonly IUserRepository _repository;

        public GetUserByIdService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse?> ExecuteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : UserMapper.ToResponse(user);
        }
    }

}
