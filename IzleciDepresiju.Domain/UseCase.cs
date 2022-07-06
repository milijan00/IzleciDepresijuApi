using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Domain
{
    public  class UseCase : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RoleUseCase> Roles { get; set; } = new List<RoleUseCase>();
    }
}
