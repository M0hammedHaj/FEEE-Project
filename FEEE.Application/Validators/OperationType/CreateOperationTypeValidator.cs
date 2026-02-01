using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FluentValidation;

namespace FEEE.Application.Validators.OperationType
{
    

    public class CreateOperationTypeValidator
        : AbstractValidator<CreateOperationTypeRequest>
    {
        public CreateOperationTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }

}
