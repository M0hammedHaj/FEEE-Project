using FEEE.Domain.Enums;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentSubject.FailStudentSubject
{
    public class FailStudentSubjectService
    {
        private readonly IStudentSubjectRepository _repository;

        public FailStudentSubjectService(IStudentSubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int studentSubjectId)
        {
            var studentSubject = await _repository.GetByIdAsync(studentSubjectId);
            if (studentSubject == null)
                throw new Exception("Student subject not found");

            if (studentSubject.Status != StudentSubjectStatus.Registered)
                throw new Exception("Only registered subject can be failed");

            studentSubject.Status = StudentSubjectStatus.Failed;

            await _repository.UpdateStatusAsync(studentSubject);
        }
    }
}
