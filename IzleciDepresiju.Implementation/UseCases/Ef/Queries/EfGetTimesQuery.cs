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
    public class EfGetTimesQuery : EfUseCase, IGetTimesQuery
    {
        public EfGetTimesQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Get all of the times";

        public string Description => "";

        public IEnumerable<TimeDto> Execute()
        {
            return this.Context.Times.Where(t => t.IsActive).Select(x => new TimeDto
            {
                Id = x.Id,
                Value = x.Value
            }).OrderBy(x => x.Value).ToList();
        }
    }
}
