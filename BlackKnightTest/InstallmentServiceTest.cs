using BlackKnightInstallment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BlackKnightTest
{
    public class InstallmentServiceTest
    {
        IInstallmentService _service;

        public InstallmentServiceTest()
        {
            _service = new InstallmentService();
            

        }

        /// <summary>
        /// Check Installment Amount for Negative Total Amount
        /// </summary>
        [Fact]
        public void CheckInstallmentforNegativeAmount()
        {
            int TotalAmount = -300;
            int NoOfInstallments = 3;

            // Act
            var okResult = _service.CalculateInstallment(TotalAmount, NoOfInstallments);

            int resultCnt = 0;
            using (IEnumerator<int> enumerator = okResult.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    resultCnt++;
            }

            // Assert
            Assert.Equal(1, resultCnt);
            Assert.Equal(TotalAmount, okResult.First());
        }

        /// <summary>
        /// Check Installment Amount for Total Amount Less than 100
        /// </summary>
        [Fact]
        public void CheckInstallmentForLessThanHundred()
        {
            int TotalAmount = 90;
            int NoOfInstallments = 3;

            // Act
            var okResult = _service.CalculateInstallment(TotalAmount, NoOfInstallments);

            int resultCnt = 0;
            using (IEnumerator<int> enumerator = okResult.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    resultCnt++;
            }

            // Assert
            Assert.Equal(NoOfInstallments, resultCnt);
            Assert.Equal(TotalAmount, okResult.First());
        }

        /// <summary>
        /// Check Installment Amounts for fraction values
        /// </summary>
        [Fact]
        public void CheckInstallmentForFraction()
        {
            int TotalAmount = 700;
            int NoOfInstallments = 3;

            // Act
            var okResult = _service.CalculateInstallment(TotalAmount, NoOfInstallments);

            int result = 0;
            int fractionCount = 0;

            bool isInt = true ;

            using (IEnumerator<int> enumerator = okResult.GetEnumerator())
            {
                while (enumerator.MoveNext()) {

                    int current = enumerator.Current;

                    result += current;

                    isInt = current % 1 == 0;

                    if(isInt == false)
                    {
                        fractionCount += 1;
                    }

                 }
            }

            // Assert
            Assert.Equal(TotalAmount, result);
            Assert.Equal(0, fractionCount);
        }

    }
}
