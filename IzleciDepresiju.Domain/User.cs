using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<MadeAppointment> MadeAppointments { get; set; } = new List<MadeAppointment>();
        public ICollection<AvailableAppointment> AvailableAppointments { get; set; } = new List<AvailableAppointment>();
    }
}
