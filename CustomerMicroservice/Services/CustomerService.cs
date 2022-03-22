using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Repositories;
using System.Net.Http;
using CustomerMicroservice.DAL.Requests;
using CustomerMicroservice.DAL.Responses;

namespace CustomerMicroservice.Services
{
    public class CustomerService : ICustomerService
    {
        private IHttpClientFactory _httpClientFactory;
        private ICustomerRepository customerRepository;

        public CustomerService(IHttpClientFactory httpClientFactory, ICustomerRepository _transactionRepository)
        {
            _httpClientFactory = httpClientFactory;
            customerRepository = _transactionRepository;
        }

        public async Task<CustomerCreationStatus> CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            CustomerCreationStatus status = customerRepository.CreateCustomer(createCustomerRequest);
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:44331/api/customer");

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44386/api/account/createAccount?customerId=" + status.CustomerId, createCustomerRequest.Customer);
            if (response.IsSuccessStatusCode)
            {
                return status;
            }
            return null;
        }

        public ApplyLoanResponse ApplyLoan(ApplyLoanRequest applyLoan)
        {
            ApplyLoanResponse status = customerRepository.ApplyLoan(applyLoan);
            return status;
        }
        public LoanStatusResponse AproveRejectLoan(LoanStatusRequest loanStatusRequest)
        {
            LoanStatusResponse status = customerRepository.AproveRejectLoan(loanStatusRequest);
            return status;
        }
        public Customer GetCustomerDetails(int customerId)
        {
            Customer customer = customerRepository.GetCustomerDetails(customerId);
            if (customer != null)
                return customer;
            else
                return null;
        }
        public CustomerLoan GetLoanDetails(int customerId)
        {
            CustomerLoan customerLoan = customerRepository.GetLoanDetails(customerId);
            if (customerLoan != null)
                return customerLoan;
            else
                return null;
        }

        public LoanStatus GetLoanStatus(int customerId)
        {
            LoanStatus loan = customerRepository.GetLoanSatus(customerId);
            if (loan != null)
                return loan;
            else
                return null;
        }
    }
}
