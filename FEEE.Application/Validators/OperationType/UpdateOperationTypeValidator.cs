using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FluentValidation;

namespace FEEE.Application.Validators.OperationType
{
 

    public class UpdateOperationTypeValidator
        : AbstractValidator<UpdateOperationTypeRequest>
    {
        public UpdateOperationTypeValidator()
        {
            RuleFor(x => x.OperationTypeId)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }

}
