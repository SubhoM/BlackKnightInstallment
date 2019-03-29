using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackKnightInstallment.Services
{
    public class InstallmentService : IInstallmentService
    {
        public IEnumerable<decimal> CalculateInstallment(decimal TotalAmount, int NoOfInstallments)
        {
            List<decimal> lstInstallment = new List<decimal>();

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
                var installmentAmt = (TotalAmount / NoOfInstallments);

                //var decInstallmentAmt = Convert.ToDecimal(installmentAmt.Substring(0,2));

                string strDecPart = (installmentAmt % 1.0m).ToString();

                decimal dPart = Convert.ToDecimal(strDecPart.Substring(0, strDecPart.Length >= 4 ? 4 : strDecPart.Length));

                Int64 iPart = (Int64)installmentAmt;

                var decInstallmentAmt = iPart + dPart;

                decimal firstInstallment = TotalAmount - decInstallmentAmt * (NoOfInstallments -1) ;

                lstInstallment.Add(firstInstallment);

                for (int i = 1; i < NoOfInstallments; i++)
                {
                    lstInstallment.Add(decInstallmentAmt);
                }

            }

            return lstInstallment;
        }

    }
}
