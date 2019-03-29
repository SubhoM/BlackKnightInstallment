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
            using (IEnumerator<decimal> enumerator = okResult.GetEnumerator())
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
            using (IEnumerator<decimal> enumerator = okResult.GetEnumerator())
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
        public void CheckInstallmentForFractionPennies()
        {
            decimal TotalAmount = 700;
            int NoOfInstallments = 3;

            // Act
            var okResult = _service.CalculateInstallment(TotalAmount, NoOfInstallments);

            decimal result = 0;
            int fractionPennyCount = 0;

            bool isFractionPennie = false ;

            using (IEnumerator<decimal> enumerator = okResult.GetEnumerator())
            {
                while (enumerator.MoveNext()) {

                    decimal current = enumerator.Current;

                    result += current;

                    isFractionPennie = (current  % 1.0m).ToString().Length > 4;

                    if(isFractionPennie == true)
                    {
                        fractionPennyCount += 1;
                    }

                 }
            }

            var _expectedResult = new List<decimal>
            {
                233.34M,
                233.33M,
                233.33M
            };

            // Assert
            Assert.Equal(_expectedResult, okResult);
            Assert.Equal(TotalAmount, result);
            Assert.Equal(0, fractionPennyCount);
        }



        /// <summary>
        /// Check Installment Amounts for fraction values Test Case 2 
        /// </summary>
        [Fact]
        public void CheckInstallmentForFractionPenniesTwo()
        {
            decimal TotalAmount = 477.53M;
            int NoOfInstallments = 3;

            // Act
            var okResult = _service.CalculateInstallment(TotalAmount, NoOfInstallments);

            decimal result = 0;
            int fractionPennyCount = 0;

            bool isFractionPennie = false;

            using (IEnumerator<decimal> enumerator = okResult.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {

                    decimal current = enumerator.Current;

                    result += current;

                    isFractionPennie = (current % 1.0m).ToString().Length > 4;

                    if (isFractionPennie == true)
                    {
                        fractionPennyCount += 1;
                    }

                }
            }

            var _expectedResult = new List<decimal>
            {
                159.19M,
                159.17M,
                159.17M
            };

            // Assert
            Assert.Equal(_expectedResult, okResult);
            Assert.Equal(TotalAmount, result);
            Assert.Equal(0, fractionPennyCount);
        }


    }
}
