using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Commands
{
    public class EfCreateMadeAppointmentCommand : EfUseCase, ICreateMadeAppointmentCommand
    {
        private IApplicationUser _user;
        public EfCreateMadeAppointmentCommand(IzleciDepresijuDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 15;

        public string Name => "Create made appointment";

        public string Description => "";

        public void Execute(CreateMadeAppointmentDto request)
        {
            var appointment = this.Context.AvailableAppointments.Find(request.AvailableAppointmentId);
            if(appointment == null)
            {
                throw new EntityNotFoundException(nameof(AvailableAppointment), request.AvailableAppointmentId);
            }
            var madeAppointment = new MadeAppointment
            {
                AvailableAppointment = appointment,
                UserId = this._user.Id
            };
            this.Context.MadeAppointments.Add(madeAppointment);
            this.Context.SaveChanges();
        }
    }
}
