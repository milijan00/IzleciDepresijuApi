using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto
{
    public class UpdateMadeAppointmentDto
    {
        public int AvailableAppointmentId { get; set; }
        public int NewAvailableAppointmentId { get; set; }
        public int UserId { get; set; }
    }
}
