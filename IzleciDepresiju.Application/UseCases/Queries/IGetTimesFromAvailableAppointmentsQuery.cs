using IzleciDepresiju.Application.UseCases.Dto.searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Queries
{
    public interface IGetTimesFromAvailableAppointmentsQuery : IQuery<SearchTimeDto, IEnumerable<SearchResultTimeDto>>
    {
    }
}
