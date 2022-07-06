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
    public class EfGetMadeAppointmentsQuery : EfUseCase, IGetMadeAppointmentsQuery
    {
        public EfGetMadeAppointmentsQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Get all made appointmemts";

        public string Description => "";

        public IEnumerable<MadeAppointmentDto> Execute()
        {
            return this.Context.MadeAppointments.Select(x => new MadeAppointmentDto
            {
                AvailableAppointmentId = x.AvailableAppointmentId,
                UserId = x.UserId
            }).ToList();
        }
    }
}
