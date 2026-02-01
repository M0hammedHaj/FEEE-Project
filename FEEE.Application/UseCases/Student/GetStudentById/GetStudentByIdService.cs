using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Students;
using FEEE.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.GetStudentById
{
    public class GetStudentByIdService
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse> ExecuteAsync(int studentId)
        {
            // 1️⃣ Simple guard
            if (studentId <= 0)
                throw new ArgumentException("Invalid student id");

            // 2️⃣ Get from repository
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                throw new Exception("Student not found");

            // 3️⃣ Map to response DTO
            return StudentMapper.ToResponse(student);
        }
    }
}
