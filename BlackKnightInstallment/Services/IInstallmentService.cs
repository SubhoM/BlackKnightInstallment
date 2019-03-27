using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackKnightInstallment.Services
{
    public interface IInstallmentService
    {
        IEnumerable<int> CalculateInstallment(int TotalAmount, int NoOfInstallments);

    }
}
