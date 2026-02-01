using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Students;
using FEEE.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.UpdateStudent
{
    public class UpdateStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<UpdateStudentRequest> _validator;

        public UpdateStudentService(
            IStudentRepository studentRepository,
            IValidator<UpdateStudentRequest> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }

        public async Task ExecuteAsync(UpdateStudentRequest request)
        {
            // 1️⃣ Validate input
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // 2️⃣ Get existing student
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new Exception("Student not found");

            // 3️⃣ Map updates
            StudentMapper.UpdateModel(student, request);

            // 4️⃣ Save changes
            await _studentRepository.UpdateAsync(student);
        }
    }
}
