using FEEE.Application.DTOs.Students;
using FEEE.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.SearchStudents
{
    public class SearchStudentsService
     : IRequestHandler<SearchStudentsQuery, List<StudentSearchResponseDto>>
    {
        private readonly IStudentRepository _studentRepository;

        public SearchStudentsService(
            IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentSearchResponseDto>> Handle(
            SearchStudentsQuery request,
            CancellationToken cancellationToken)
        {
            return await _studentRepository.SearchAsync(
                request.UniversityNumber,
                request.FullName);
        }
    }
}
