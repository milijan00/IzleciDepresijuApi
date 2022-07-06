using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto.searches
{
    public class SearchResultTimeDto 
    {
        public int AvailableAppointmentId { get; set; }
        public string TimeFromValue { get; set; }
        public string TimeToValue { get; set; }

    }
}
