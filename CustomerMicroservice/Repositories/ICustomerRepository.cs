using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.DAL.Requests;
using CustomerMicroservice.DAL.Responses;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerDetails(int customerId);
        CustomerLoan GetLoanDetails(int customerId);
        CustomerCreationStatus CreateCustomer(CreateCustomerRequest createCustomerRequest);
        ApplyLoanResponse ApplyLoan(ApplyLoanRequest applyLoan);
        public LoanStatusResponse AproveRejectLoan(LoanStatusRequest loanStatusRequest);
        public LoanStatus GetLoanSatus(int customerId);
    }
}
