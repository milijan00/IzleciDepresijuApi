using IzleciDepresiju.Application.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Commands
{
    public interface ICreateMadeAppointmentCommand : ICommand<CreateMadeAppointmentDto>
    {
    }
}
