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
    public class UpdateRoleUseCaseValidator : AbstractValidator<UpdateRoleUseCasesDto>
    {
        public UpdateRoleUseCaseValidator(IzleciDepresijuDbContext context)
        {
            RuleFor(x => x.RoleId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Role id must not be null.")
                .Must(id => id != 0).WithMessage("Role id cannot be 0.")
                .Must(id => context.Roles.Any(r => r.Id == id)).WithMessage("There is no such role");
            RuleFor(x => x.UseCaseIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("You must send some use cases.")
                .Must(arr => arr.Distinct().Count() == arr.Count()).WithMessage("There are some duplicates in the array.")
                .Must(arr => arr.Where(id => context.UseCases.Any(u => u.Id == id)).Count() == arr.Count()).WithMessage("Some use cases don't exist.");
            //RuleFor(x => x.UseCaseId)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull().WithMessage("Use case id must not be null.")
            //    .Must(id => id != 0).WithMessage("Use case id cannot be 0.")
            //    .Must(id => context.Use.Any(r => r.Id == id)).WithMessage("There is no such role");
        }
    }
}
