using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetAvailableAppointmentsQuery : EfUseCase, IGetAvailableAppointmentsQuery
    {
        public EfGetAvailableAppointmentsQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get all available appointments";

        public string Description => "";

        public IEnumerable<AvailableAppointmentsDto> Execute()
        {
            return this.Context.AvailableAppointments.Where(a => a.IsActive).Select(x => new AvailableAppointmentsDto
            {
                Id = x.Id,
                TimeFromId = x.TimeFromId,
                TimeToId = x.TimeToId,
                UserId = x.TherapistId,
                WorkdayId = x.WorkdayId
            }).ToList();
        }
    }
}
