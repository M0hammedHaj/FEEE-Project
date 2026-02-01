using FEEE.Domain.Enums;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentSubject.PassStudentSubject
{
    public class PassStudentSubjectService
    {
        private readonly IStudentSubjectRepository _repository;

        public PassStudentSubjectService(IStudentSubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int studentSubjectId)
        {
            var studentSubject = await _repository.GetByIdAsync(studentSubjectId);
            if (studentSubject == null)
                throw new Exception("Student subject not found");

            // Business rule
            if (studentSubject.Status != StudentSubjectStatus.Registered)
                throw new Exception("Only registered subject can be passed");

            studentSubject.Status = StudentSubjectStatus.Passed;

            await _repository.UpdateStatusAsync(studentSubject);
        }
    }
}
