using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackKnightInstallment.Services
{
    public interface IInstallmentService
    {
        IEnumerable<decimal> CalculateInstallment(decimal TotalAmount, int NoOfInstallments);

    }
}
