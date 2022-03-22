using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.DAL.Requests;
using CustomerMicroservice.DAL.Responses;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerDetails(int customerId);
        CustomerLoan GetLoanDetails(int customerId);
        LoanStatus GetLoanStatus(int customerId);

        public Task<CustomerCreationStatus> CreateCustomer(CreateCustomerRequest createCustomerRequest);
        public ApplyLoanResponse ApplyLoan(ApplyLoanRequest applyLoan);
        public LoanStatusResponse AproveRejectLoan(LoanStatusRequest loanStatusRequest); 
    }
}
