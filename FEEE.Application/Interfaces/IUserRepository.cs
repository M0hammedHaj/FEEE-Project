using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<int> AddAsync(UserModel model);
        Task DeleteAsync(int id);

    }
}
