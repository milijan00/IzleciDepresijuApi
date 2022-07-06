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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(IzleciDepresijuDbContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get all users.";

        public string Description => "";

        public IEnumerable<UserDto> Execute()
        {
            return this.Context.Users.Where(u => u.IsActive && u.RoleId == 3).Select(x => new UserDto
            {
                Id = x.Id,
                Image = x.Image,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
        }
    }
}
