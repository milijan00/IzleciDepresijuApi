using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetWorkdaysOfTherapistQuery : EfUseCase, IGetWorkdaysOfTherapistQuery
    {
        public EfGetWorkdaysOfTherapistQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Get all workdays of a specific therapist.";

        public string Description => "";

        public IEnumerable<WorkdayDto> Execute(int request)
        {
            var therapist = this.Context.Users.Find(request);
            if(therapist == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }
            return this.Context.AvailableAppointments.Include(a => a.Workday).Where(a => a.IsActive && a.TherapistId == request).Select(x => new WorkdayDto
            {
                Id = x.WorkdayId,
                Name = x.Workday.Name
            }).Distinct().ToList();
        }
    }
}
