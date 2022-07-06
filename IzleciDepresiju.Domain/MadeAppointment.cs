using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Domain
{
    public class MadeAppointment
    {
        public int UserId { get; set; }
        public int AvailableAppointmentId { get; set; }
        public DateTime BookedAt { get; set; }
        public User User  { get; set; }
        public AvailableAppointment  AvailableAppointment  { get; set; }
    }
}
