using FEEE.Application.DTOs.StudentSubject;
using FEEE.Application.Mappings.StudentSubject;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentSubject.GetStudentSubjects
{
    public class GetStudentSubjectsService
    {
        private readonly IStudentSubjectRepository _repository;

        public GetStudentSubjectsService(IStudentSubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentSubjectListItemResponse>> ExecuteAsync(GetStudentSubjectsRequest request)
        {
            var subjects = await _repository.GetByStudentIdAsync(request.StudentId);

            return subjects
                .Select(StudentSubjectMapper.ToListItem)
                .ToList();
        }
    }
}
