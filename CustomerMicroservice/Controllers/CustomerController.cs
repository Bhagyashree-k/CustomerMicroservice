using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;
using CustomerMicroservice.Repositories;
using CustomerMicroservice.Services;
using CustomerMicroservice.DAL.Requests;
using CustomerMicroservice.DAL.Responses;
using CustomerMicroservice.Data;

namespace CustomerMicroservice.Controllers
{
    //http://localhost:44331/api/customer/
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        
        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet("getCustomerDetails")]
        public IActionResult GetCustomerDetails(int customerId)
        {
            if(customerId <= 0)
            {
                return BadRequest("Customer ID must be greater than zero");
            }
            else
            {
                Customer customer = customerService.GetCustomerDetails(customerId);
                if (customer != null)
                    return Ok(customer);
                else
                    return NoContent();
            }
        }

        [HttpPost("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            CreateCustomerRequest createCustomerRequest = new CreateCustomerRequest();
            createCustomerRequest.Customer = customer;
            if (ModelState.IsValid)
            {
                CustomerCreationStatus status = await customerService.CreateCustomer(createCustomerRequest);
                if (status != null)
                {
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("Customer creation failed");
            }

            //if (ModelState.IsValid)
            //{
            //    CustomerCreationStatus status = await customerService.CreateCustomer(customer);
            //
            //      return Ok(status);
            // 
            //   
            //}
            //else
            //{
            //    return BadRequest("Customer creation failed");
            //}
        }

        [HttpPost("applyLoan")]
        public IActionResult ApplyLoan([FromBody] CustomerLoan customerLoan)
        {
            ApplyLoanRequest applyLoanRequest = new ApplyLoanRequest();
            applyLoanRequest.customerLoan = customerLoan;
            if (ModelState.IsValid)
            {
                ApplyLoanResponse status = customerService.ApplyLoan(applyLoanRequest);
                if (status != null)
                {
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("Unsuccessfull");
            }

        }

        [HttpGet("getLoanDetails")]
        public IActionResult GetLoanDetails(int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest("Customer ID must be greater than zero");
            }
            else
            {
                CustomerLoan customerLoan = customerService.GetLoanDetails(customerId);
                if (customerLoan != null)
                    return Ok(customerLoan);
                else
                    return NoContent();
            }
        }

        [HttpPost("aproveRejectLoan")]
        public IActionResult AproveRejectLoan([FromBody] LoanStatus loanstatus)
        {
            LoanStatusRequest loanStatusRequest= new LoanStatusRequest();
            loanStatusRequest.LoanStatus=loanstatus;
            
            if (ModelState.IsValid)
            {
                LoanStatusResponse status = customerService.AproveRejectLoan(loanStatusRequest);
                if (status != null)
                {
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("Unsuccessfull");
            }

        }

        [HttpGet("getLoanStatus")]
        public IActionResult GetLoanStatus(int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest("Customer ID must be greater than zero");
            }
            else
            {
                LoanStatus status = customerService.GetLoanStatus(customerId);
                if (status != null)
                    return Ok(status);
                else
                    return NoContent();
            }
        }
        [HttpGet("getAllLoans")]
        public IActionResult GetAllLoanRequest()
        {

            List<CustomerLoan> customerLoans = CustomerDbHelper.customersLoan;
            return Ok(customerLoans);
        }
    }
}