using FEEE.Domain.Enums;
using FEEE.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.ArchiveStudent
{
    public class ArchiveStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public ArchiveStudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task ExecuteAsync(int studentId)
        {
            // 1️⃣ Guard
            if (studentId <= 0)
                throw new ArgumentException("Invalid student id");

            // 2️⃣ Get student
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                throw new Exception("Student not found");

            // 3️⃣ Business rule
            if (student.Status == StudentStatus.Archived)
                throw new Exception("Student is already archived");

            // 4️⃣ Archive
            student.Status = StudentStatus.Archived;

            // 5️⃣ Save
            await _studentRepository.UpdateAsync(student);
        }
    }
}
