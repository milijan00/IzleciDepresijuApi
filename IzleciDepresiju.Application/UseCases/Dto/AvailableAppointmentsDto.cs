using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto
{
    public  class AvailableAppointmentsDto
    {
        public int Id { get; set; }
        public int WorkdayId { get; set; }
        public int TimeFromId { get; set; }
        public int TimeToId { get; set; }
        public int UserId { get; set; }
    }
}
