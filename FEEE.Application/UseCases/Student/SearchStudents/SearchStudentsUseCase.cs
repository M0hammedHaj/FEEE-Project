using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Students;
using FEEE.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.SearchStudents
{
    public class SearchStudentsUseCase
    {
        private readonly IStudentRepository _studentRepository;

        public SearchStudentsUseCase(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentResponse>> ExecuteAsync(
            string searchTerm,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<StudentResponse>();

            var students = await _studentRepository.SearchStudentsAsync(searchTerm, cancellationToken);

            return StudentMapper.ToResponseList(students);
        }
    }
}
