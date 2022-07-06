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
    public class EfCreateUseCaseCommand : EfUseCase, ICreateUseCaseCommand
    {
        private CreateUseCaseValidator _validator;
        public EfCreateUseCaseCommand(IzleciDepresijuDbContext context, CreateUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create a usecase.";

        public string Description => "Create a usecase via entity framework.";

        public void Execute(CreateUseCaseDto request)
        {
            var result = this._validator.Validate(request);
            if (result.IsValid)
            {
                var usecase = new UseCase
                {
                    Name = request.Name,
                    Description = request.Description
                };
                this.Context.UseCases.Add(usecase);
                this.Context.SaveChanges();
            }else
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
