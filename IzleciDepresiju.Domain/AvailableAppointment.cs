using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Domain
{
    public class AvailableAppointment : Entity
    {
        public int TherapistId { get; set; }
        public int WorkdayId { get; set; }
        public int TimeFromId { get; set; }
        public int TimeToId { get; set; }
        public User Therapist  { get; set; }
        public Workday Workday  { get; set; }
        public Time TimeFrom  { get; set; }
        public Time TimeTo  { get; set; }

        public ICollection<MadeAppointment> MadeAppointments { get; set; } = new List<MadeAppointment>();

    }
}
