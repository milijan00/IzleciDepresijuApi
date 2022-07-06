using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Domain
{
    public class Time : Entity
    {
        public string Value { get; set; }
        public ICollection<AvailableAppointment> AvailableAppointmentsForStartingTime { get; set; } = new List<AvailableAppointment>();
        public ICollection<AvailableAppointment> AvailableAppointmentsForEndingTime { get; set; } = new List<AvailableAppointment>();
    }
}
