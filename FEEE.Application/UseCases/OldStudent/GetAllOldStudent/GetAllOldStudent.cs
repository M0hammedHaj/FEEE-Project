using FEEE.Application.DTOs.OldStudents;
using FEEE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.Mappings.OldStudents;

namespace FEEE.Application.UseCases.OldStudent.GetAllOldStudent
{
    public class ListOldStudentsService
    {
        private readonly IOldStudentRepository _repo;

        public ListOldStudentsService(IOldStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<OldStudentDto>> ExecuteAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(x => x.ToDto()).ToList();
        }
    }

}
