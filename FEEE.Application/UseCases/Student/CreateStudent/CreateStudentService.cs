using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Students;
using FEEE.Domain.Models;
using FEEE.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Student.CreateStudent
{
    public class CreateStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<CreateStudentRequest> _validator;

        public CreateStudentService(
            IStudentRepository studentRepository,
            IValidator<CreateStudentRequest> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }

        public async Task<int> ExecuteAsync(CreateStudentRequest request)
        {
            // 1️⃣ Validate input
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // 2️⃣ Map via Mapper
            var student = StudentMapper.ToModel(request);

            // 3️⃣ Save
            await _studentRepository.AddAsync(student);

            // 4️⃣ Return ID
            return student.StudentId;
        }
    }
}
