using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto
{
    public class UsersMadeAppointmentDto 
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int WorkdayId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Workday { get; set; }
        public string TimeFromValue { get; set; }
        public string TimeToValue { get; set; }
    }
}
