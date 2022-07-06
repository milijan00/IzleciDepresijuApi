using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases.Dto
{
    public class UpdateRoleUseCasesDto
    {
        public int RoleId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
