using FEEE.Application.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace FEEE.Application.Validators.Students
{
    public class CreateStudentRequestValidator
        : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(x => x.UniversityNumber)
                .NotEmpty()
                .WithMessage("University number is required.")
                .MaximumLength(50);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MaximumLength(100);

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Today)
                .WithMessage("Birth date must be in the past.")
                .When(x => x.BirthDate.HasValue);

            RuleFor(x => x.CityId)
                .GreaterThan(0)
                .When(x => x.CityId.HasValue);

            RuleFor(x => x.SectionId)
                .GreaterThan(0)
                .When(x => x.SectionId.HasValue);

            RuleFor(x => x.YearId)
                .GreaterThan(0)
                .When(x => x.YearId.HasValue);
        }
    }
}
