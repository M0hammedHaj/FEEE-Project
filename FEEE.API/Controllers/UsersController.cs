using FEEE.Application.DTOs.User;
using FEEE.Application.UseCases.User.CreateUser;
using FEEE.Application.UseCases.User.DeleteUser;
using FEEE.Application.UseCases.User.GetAllUsers;
using FEEE.Application.UseCases.User.GetUserById;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserService _create;
        private readonly DeleteUserService _delete;
        private readonly GetAllUsersService _getAll;
        private readonly GetUserByIdService _getById;

        public UsersController(
            CreateUserService create,
            DeleteUserService delete,
            GetAllUsersService getAll,
            GetUserByIdService getById)
        {
            _create = create;
            _delete = delete;
            _getAll = getAll;
            _getById = getById;
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAll.ExecuteAsync();
            return Ok(result);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.ExecuteAsync(id);
            return Ok(result);
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _delete.ExecuteAsync(id);
            return NoContent();
        }
    }


}
