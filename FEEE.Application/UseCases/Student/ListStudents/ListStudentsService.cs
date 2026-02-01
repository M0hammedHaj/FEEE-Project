using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Students;
using FEEE.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.ListStudents
{
    public class ListStudentsService
    {
        private readonly IStudentRepository _studentRepository;

        public ListStudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentListItemResponse>> ExecuteAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students
                .Select(StudentMapper.ToListItem)
                .ToList();
        }
    }
}
