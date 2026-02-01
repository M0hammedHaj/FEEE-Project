using FEEE.Application.DTOs.OldStudents;
using FEEE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.Mappings.OldStudents;


namespace FEEE.Application.UseCases.OldStudent.GetByIdOldStudent
{
    public class GetOldStudentByIdService
    {
        private readonly IOldStudentRepository _repo;

        public GetOldStudentByIdService(IOldStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<OldStudentDto?> ExecuteAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            return student?.ToDto();
        }
    }

}
