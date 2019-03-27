using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackKnightInstallment.Services
{
    public class InstallmentService : IInstallmentService
    {
        public IEnumerable<int> CalculateInstallment(int TotalAmount, int NoOfInstallments)
        {
            List<int> lstInstallment = new List<int>();

            if(TotalAmount < 0)
            {
                lstInstallment.Add(TotalAmount);
                return lstInstallment;
            }

            if (TotalAmount < 100)
            {
                lstInstallment.Add(TotalAmount);

                for(int i=1; i<NoOfInstallments; i++)
                {
                    lstInstallment.Add(0);
                }
                return lstInstallment;
            }

            if(NoOfInstallments ==1)
            {
                lstInstallment.Add(TotalAmount);

                return lstInstallment;
            }

            if (NoOfInstallments > 1)
            {
                var installmentAmt = TotalAmount / NoOfInstallments;

                decimal dPart = installmentAmt % 1.0m;

                int iPart = (int)installmentAmt;

                int firstInstallment = TotalAmount -  iPart * (NoOfInstallments -1) ;

                lstInstallment.Add(firstInstallment);

                for (int i = 1; i < NoOfInstallments; i++)
                {
                    lstInstallment.Add(iPart);
                }

            }

            return lstInstallment;
        }

    }
}
