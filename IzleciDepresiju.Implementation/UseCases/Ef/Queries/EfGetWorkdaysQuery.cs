using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetWorkdaysQuery : EfUseCase, IGetWorkdaysQuery
    {
        public EfGetWorkdaysQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Get all workdays query";

        public string Description => "";

        public IEnumerable<WorkdayDto> Execute()
        {
            return this.Context.Workdays.Where(d => d.IsActive).Select(x => new WorkdayDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
