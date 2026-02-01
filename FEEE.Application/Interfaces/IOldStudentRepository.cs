using FEEE.Domain.Entities;
using FEEE.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Interfaces
{
    public interface IOldStudentRepository
    {
        Task<List<OldStudent>> GetAllAsync();
        Task<OldStudent?> GetByIdAsync(int id);
    }

}
