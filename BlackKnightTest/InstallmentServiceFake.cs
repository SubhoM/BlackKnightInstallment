using System;
using Xunit;

namespace BlackKnightTest
{
    using global::BlackKnightInstallment.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InstallmentServiceFake : IInstallmentService
        {
            private readonly List<decimal> _lstInstallment;

            public InstallmentServiceFake()
            {
                _lstInstallment = new List<decimal>(){100,100,100};

            }

            public IEnumerable<decimal> CalculateInstallment(decimal TotalAmount, int NoOfInstallments)
            {
                return _lstInstallment;
            } 


        }
    

}
