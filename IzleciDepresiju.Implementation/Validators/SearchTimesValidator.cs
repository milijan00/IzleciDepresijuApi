using FluentValidation;
using IzleciDepresiju.Application.UseCases.Dto.searches;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.Validators
{
    public class SearchTimesValidator : AbstractValidator<SearchTimeDto>
    {
        public SearchTimesValidator(IzleciDepresijuDbContext context)
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User id must not be null")
                .Must(id => id > 0).WithMessage("User id must not be less than or equal to 0.")
                .Must(id => context.Users.Any(u => u.Id == id)).WithMessage("There is no given user.")
                .Must(id => context.Users.Find(id).RoleId == 3).WithMessage("Given user must be a therapist.");

            RuleFor(x => x.WorkdayId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Workday id must not be null")
                .Must(id => id > 0).WithMessage("Workday id must not be less than or equal to 0.")
                .Must(id => context.Workdays.Any(w => w.Id == id)).WithMessage("There is no given workday.");
        }
    }
}
