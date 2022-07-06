using FluentValidation;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using IzleciDepresiju.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Commands
{
    public class EfUpdateRoleUseCasesCommand : EfUseCase, IUpdateRoleUseCasesCommand
    {
        private UpdateRoleUseCaseValidator _validator;
        public EfUpdateRoleUseCasesCommand(IzleciDepresijuDbContext context, UpdateRoleUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;
        public string Name => "Ef update a role usecase.";
        public string Description => "Update a role usecase via Entity Framework.";
        public void Execute(UpdateRoleUseCasesDto request)
        {
            var result = this._validator.Validate(request);
            if (result.IsValid)
            {
                var notInsertedUseCasesIds = request.UseCaseIds.Where(id => !Context.RolesUseCases.Where(r => r.RoleId == request.RoleId).Any(r => r.UseCaseId == id));
                if (notInsertedUseCasesIds.Any())
                {
                    var role = Context.Roles.Find(request.RoleId);
                    foreach(var id in notInsertedUseCasesIds)
                    {
                        role.UseCases.Add(new RoleUseCase{
                            Role = role,
                            UseCaseId = id
                        });
                    }
                    this.Context.SaveChanges();
                }
            }else
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
