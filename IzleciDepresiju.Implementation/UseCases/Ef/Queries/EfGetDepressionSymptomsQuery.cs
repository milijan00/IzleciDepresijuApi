using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation.DataAccess;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetDepressionSymptomsQuery : EfUseCase, IGetDepressionSymptomsQuery
    {
        public EfGetDepressionSymptomsQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get all depression symptoms";

        public string Description => "";

        public IEnumerable<DepressionSymptomDto> Execute()
        {
            return this.Context.DepressionSymptoms.Where(d => d.IsActive).Select(x => new DepressionSymptomDto
            {
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }
    }
}
