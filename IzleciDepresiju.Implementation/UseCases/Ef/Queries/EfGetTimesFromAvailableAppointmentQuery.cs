using FluentValidation;
using IzleciDepresiju.Application.UseCases.Dto.searches;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation.DataAccess;
using IzleciDepresiju.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef.Queries
{
    public class EfGetTimesFromAvailableAppointmentQuery : EfUseCase, IGetTimesFromAvailableAppointmentsQuery
    {

        private SearchTimesValidator _validator;
        public EfGetTimesFromAvailableAppointmentQuery(IzleciDepresijuDbContext context, SearchTimesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Get times from specific available appointment";

        public string Description => "";

        public IEnumerable<SearchResultTimeDto> Execute(SearchTimeDto request)
        {
            var result = this._validator.Validate(request);
            if(result.IsValid)
            {
                return this.Context.AvailableAppointments.Where(a => a.TherapistId == request.UserId && a.WorkdayId == request.WorkdayId && a.MadeAppointments.Count == 0).Select(a => new SearchResultTimeDto
                {
                    AvailableAppointmentId = a.Id,
                    TimeFromValue = a.TimeFrom.Value,
                    TimeToValue = a.TimeTo.Value
                }).ToList();
            }else
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
