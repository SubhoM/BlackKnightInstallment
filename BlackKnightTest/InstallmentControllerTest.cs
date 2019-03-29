using BlackKnightInstallment.Controllers;
using BlackKnightInstallment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlackKnightTest
{

    public class InstallmentControllerTest
    {
        InstallmentController _controller;
        IInstallmentService _service;

        public InstallmentControllerTest()
        {
            _service = new InstallmentServiceFake();
            _controller = new InstallmentController(_service);

        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            int TotalAmount = 300;
            int NoOfInstallments = 3;

            // Act
            var okResult = _controller.GetInstallmentAmount(TotalAmount, NoOfInstallments);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsInstallments()
        {
            decimal TotalAmount = 500m;
            int NoOfInstallments = 3;


            // Act
            var okResult = _controller.GetInstallmentAmount(TotalAmount, NoOfInstallments) as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<decimal>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }



    }
}
