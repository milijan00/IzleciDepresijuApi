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
    public class EfGetNavigationLinksQuery : EfUseCase, IGetNavigationLinksQuery
    {
        public EfGetNavigationLinksQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get all navigation links";

        public string Description => "";

        public IEnumerable<NavigationLinkDto> Execute()
        {
            return this.Context.NavigationLinks.Where(n => n.IsActive).Select(x => new NavigationLinkDto
            {
                Id = x.Id,
                Name = x.Name,
                Route = x.Route,
                State = x.State
            }).OrderBy(x => x.Id).ToList();
        }
    }
}
