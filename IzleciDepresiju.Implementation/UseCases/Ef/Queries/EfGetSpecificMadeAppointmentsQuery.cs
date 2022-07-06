using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetSpecificMadeAppointmentsQuery : EfUseCase, IGetSpecificMadeAppointmentsQuery
    {
        public EfGetSpecificMadeAppointmentsQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Get specific made appointemts.";

        public string Description => "";

        public IEnumerable<UsersMadeAppointmentDto> Execute(int request)
        {
            var appointments = this.Context.MadeAppointments.Where(m => m.UserId == request).Select(m => m.AvailableAppointmentId).ToList();
            var response = this.Context.AvailableAppointments.Where(a => appointments.Contains(a.Id))
                .Include(a => a.Therapist)
                .Include(a => a.Workday)
                .Include(a => a.TimeFrom)
                .Include(a => a.TimeTo).Select(x => new UsersMadeAppointmentDto
                {
                    Id = x.Id,
                    Firstname = x.Therapist.FirstName,
                    Lastname = x.Therapist.LastName,
                    Phone = x.Therapist.Phone,
                    Workday = x.Workday.Name,
                    TimeFromValue = x.TimeFrom.Value,
                    TimeToValue = x.TimeTo.Value,
                    TherapistId= x.TherapistId,
                    WorkdayId = x.WorkdayId
                }).ToList();

            return response;
        }
    }
}
