using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Application.UseCases
{
    public interface IQuery<TRequest, TResponse> : IUseCase
    {
        TResponse Execute(TRequest request);
    }
     public interface IQuery<TResponse> : IUseCase
    {
        TResponse Execute();
    }
}

