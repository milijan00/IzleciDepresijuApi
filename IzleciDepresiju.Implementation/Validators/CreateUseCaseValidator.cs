using FluentValidation;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.Validators
{
    public class CreateUseCaseValidator : AbstractValidator<CreateUseCaseDto>
    {
        public CreateUseCaseValidator(IzleciDepresijuDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Usecase name must not be null or empty.")
                .MaximumLength(50).WithMessage("Name can have up to 50 characters.")
                .Must(name => !context.UseCases.Any(u => u.Name == name)).WithMessage("There is already an usecase with given name.");
        }
    }
}
