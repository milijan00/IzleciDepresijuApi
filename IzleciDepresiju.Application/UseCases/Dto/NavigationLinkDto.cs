using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto
{
    public class NavigationLinkDto
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
    }
}
