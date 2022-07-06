using IzleciDepresiju.Application.Exceptions;
using IzleciDepresiju.Application.Logging;
using IzleciDepresiju.Application.UseCases;
using IzleciDepresiju.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;

        public UseCaseHandler(
            IExceptionLogger logger,
            IApplicationUser user
            )
        {
            _logger = logger;
            _user = user;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
    public TResponse HandleQuery< TResponse>(IQuery<TResponse> query)
        {
            try
            {
                HandleLoggingAndAuthorization(query);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute();

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization(IUseCase useCase)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            //var log = new UseCaseLog
            //{
            //    User = _user.Identity,
            //    ExecutionDateTime = DateTime.UtcNow,
            //    UseCaseName = useCase.Name,
            //    UserId = _user.Id,
            //    Data = JsonConvert.SerializeObject(data),
            //    IsAuthorized = isAuthorized
            //};

            //_useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            }
        }
    }
}
