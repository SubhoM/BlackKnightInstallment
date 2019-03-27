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
            private readonly List<int> _lstInstallment;

            public InstallmentServiceFake()
            {
                _lstInstallment = new List<int>(){100,100,100};

            }

            public IEnumerable<int> CalculateInstallment(int TotalAmount, int NoOfInstallments)
            {
                return _lstInstallment;
            } 


        }
    

}
