using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Commands
{
    public class EfDeleteMadeAppointmentCommand : EfUseCase, IDeleteMadeAppoointmentCommand
    {
        public EfDeleteMadeAppointmentCommand(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Delete a made appointment.";

        public string Description => "";

        public void Execute(int request)
        {
            var madeAppointment = this.Context.MadeAppointments.FirstOrDefault(a => a.AvailableAppointmentId == request);
            if(madeAppointment == null)
            {
                throw new EntityNotFoundException(nameof(MadeAppointment), request);
            }
            this.Context.MadeAppointments.Remove(madeAppointment);
            this.Context.SaveChanges();
        }
    }
}
