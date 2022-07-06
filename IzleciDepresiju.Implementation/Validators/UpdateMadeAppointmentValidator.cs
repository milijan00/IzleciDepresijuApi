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
    public class UpdateMadeAppointmentValidator : AbstractValidator<UpdateMadeAppointmentDto>
    {
        public UpdateMadeAppointmentValidator(IzleciDepresijuDbContext context)
        {
            RuleFor(x => x.AvailableAppointmentId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id > 0).WithMessage("Available appointment id must be greater than 0.")
                .Must(id => context.AvailableAppointments.Any(a => a.Id == id)).WithMessage("Given available appointment doesn't exist.");


            RuleFor(x => x.NewAvailableAppointmentId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id > 0).WithMessage("New available appointment id must be greater than 0.")
                .Must(id => context.AvailableAppointments.Any(a => a.Id == id)).WithMessage("Given new available appointment doesn't exist.");
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id > 0).WithMessage("User id must be greater than 0.")
                .Must(id => context.Users.Any(u => u.Id == id)).WithMessage("Given user doesn't exist");
                
        }
    }
}
