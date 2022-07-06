using IzleciDepresiju.Implementation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.UseCases.Ef {

    public class EfUseCase
    {
        public EfUseCase(IzleciDepresijuDbContext context)
        {
            Context = context;
        }

        protected IzleciDepresijuDbContext Context { get; }
    }
}
