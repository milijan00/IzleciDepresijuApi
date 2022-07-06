using IzleciDepresiju.Application.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Queries
{
    public  interface IGetMadeAppointmentsQuery : IQuery<IEnumerable<MadeAppointmentDto>>
    {
    }
}
