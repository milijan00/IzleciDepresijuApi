using FluentValidation;
using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using IzleciDepresiju.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Commands
{
    public class EfUpdateMadeAppointmentCommand : EfUseCase, Application.UseCases.Commands.IUpdateMadeAppointmentCommand
    {
        private UpdateMadeAppointmentValidator _validator;
        public EfUpdateMadeAppointmentCommand(IzleciDepresijuDbContext context,UpdateMadeAppointmentValidator validator) : base(context)
        {
            this._validator = validator;
        }

        public int Id => 18;

        public string Name => "Update a made appointment.";

        public string Description => "";

        public void Execute(UpdateMadeAppointmentDto request)
        {
            var result = this._validator.Validate(request);
            if (result.IsValid)
            {
                var madeAppointment = this.Context.MadeAppointments.First(a => a.AvailableAppointmentId == request.AvailableAppointmentId);
                //madeAppointment.AvailableAppointmentId = request.NewAvailableAppointmentId;
                var newMadeAppointment = new MadeAppointment
                {
                    AvailableAppointmentId = request.NewAvailableAppointmentId,
                    UserId = request.UserId
                };
                this.Context.MadeAppointments.Remove(madeAppointment);
                this.Context.MadeAppointments.Add(newMadeAppointment);
                this.Context.SaveChanges();
            }else
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
