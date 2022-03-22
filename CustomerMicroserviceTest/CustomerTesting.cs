using System;
using CustomerMicroservice.Controllers;
using NUnit.Framework;
using Moq;
using CustomerMicroservice.Services;
using CustomerMicroservice.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;

namespace CustomerMicroserviceTest
{
    [TestFixture]
    public class CustomerTesting
    {
        private CustomerController controller;
        private Mock<ICustomerService> mockservice;
    
        [SetUp]
        public void Setup()
        {
            mockservice = new Mock<ICustomerService>();
            controller = new CustomerController(mockservice.Object);
        }

        [Test]
        public void GetCustomerDetail_InvalidInput_ReturnsBadRequest()
        {
            var id = 0;
            IActionResult result = controller.GetCustomerDetails(id);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void  GetCustomerDetail_ValidInput_ReturnsNoContent()
        {
            var id = 100;
            IActionResult result = controller.GetCustomerDetails(id);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void GetCustomerDetail_ValidInput_ReturnsOkResult()
        {
            var id = 10;
            Customer customer = new Customer() { CustomerId = id, FirstName = "Rohini", LastName = "Thorat", Address = "Mumbai", DateOfBirth = new DateTime(1999, 02, 02), PanNumber = "MFPFS10001A", Password = "ABCa12345" };
            mockservice.Setup(x => x.GetCustomerDetails(id)).Returns(customer);
            var result = controller.GetCustomerDetails(id);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task CreateCustomer_InvalidModel_ReturnsBadRequest()
        {
            Customer customer = new Customer() { FirstName = " ", LastName = "Kohli", Address = "Delhi", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B", Password = "ABCa123422" };
            controller.ModelState.AddModelError("FirstName", "Required");        
            var result = await controller.CreateCustomer(customer);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task CreateCustomer_ValidModel_ReturnsNoContent()
        {
            Customer customer = new Customer() { CustomerId = 1, FirstName = "Virat", LastName = "Kohli", Address = "Delhi", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B", Password = "ABCa123422" };
            CustomerCreationStatus status =null;
            mockservice.Setup(x => x.CreateCustomer(customer)).ReturnsAsync(status);
            var result = await controller.CreateCustomer(customer);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task CreateCustomer_ValidModel_ReturnsOkResult()
        {
            Customer customer = new Customer() { CustomerId = 1, FirstName = "Virat", LastName = "Kohli", Address = "Delhi", DateOfBirth = new DateTime(1950, 11, 05), PanNumber = "MFPFS10004B", Password = "ABCa123422" };
            CustomerCreationStatus status = new CustomerCreationStatus() { CustomerId = 1004, Status = "Success" };
            mockservice.Setup(x => x.CreateCustomer(customer)).ReturnsAsync(status);
            var result = await controller.CreateCustomer(customer);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }
     }
}