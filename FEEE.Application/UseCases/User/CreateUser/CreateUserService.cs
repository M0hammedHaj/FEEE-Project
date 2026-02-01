using FEEE.Application.DTOs.User;
using FEEE.Application.Mappings.User;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.User.CreateUser
{
    public class CreateUserService
    {
        private readonly IUserRepository _repository;

        public CreateUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(CreateUserRequest request)
        {
            var model = UserMapper.ToModel(request);
            var id = await _repository.AddAsync(model);
            return id;
        }
    }

}
