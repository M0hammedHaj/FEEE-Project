using FEEE.Application.DTOs.Students;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.SearchStudents
{
    public class SearchStudentsQuery
     : IRequest<List<StudentSearchResponseDto>>
    {
        public string? UniversityNumber { get; init; }
        public string? FullName { get; init; }
    }
}
