using CustomerMicroservice.DAL.Requests;
using CustomerMicroservice.DAL.Responses;
using CustomerMicroservice.Data;
using CustomerMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CustomerMicroservice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContextOptions<CustomerDbContext> options;
        public CustomerRepository()
        {
            options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
        }
        public CustomerCreationStatus CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            CustomerCreationStatus creationStatus = new CustomerCreationStatus();
            try
            {
                CustomerCreationStatus customerstatus = new CustomerCreationStatus();
                createCustomerRequest.Customer.CustomerId = (CustomerDbHelper.customers.Max(a => a.CustomerId)) + 1;
                CustomerDbHelper.customers.Add(createCustomerRequest.Customer);
                int id = createCustomerRequest.Customer.CustomerId;
                customerstatus.CustomerId = id;
                customerstatus.Status = "Success";
                return customerstatus;

                //using (var context = new CustomerDbContext(options))
                //{
                //    Customer customer = new Customer
                //    {
                //        CustomerId = createCustomerRequest.Customer.CustomerId,
                //        FirstName = createCustomerRequest.Customer.FirstName,
                //        LastName = createCustomerRequest.Customer.LastName,
                //        Address = createCustomerRequest.Customer.Address,
                //        DateOfBirth = createCustomerRequest.Customer.DateOfBirth,
                //        PanNumber = createCustomerRequest.Customer.PanNumber,
                //        Password = createCustomerRequest.Customer.Password
                //    };

                //    context.customers.Add(customer);
                //    context.SaveChanges();

                //    creationStatus.CustomerId = createCustomerRequest.Customer.CustomerId;
                //    creationStatus.Status = "Successfully created";
                //}
            }
            catch(Exception)
            {
                return null;
            }
            //return creationStatus;

        }

        public Customer GetCustomerDetails(int customerId)
        {
            //Customer customer = new Customer();
            //try
            //{
            //    using(var context = new CustomerDbContext(options))
            //    {
            //        customer = context.customers.FirstOrDefault(x => x.CustomerId == customerId);               
            //    }
            //    
            //}
            try
            {
                return CustomerDbHelper.customers.Find(x => x.CustomerId == customerId);
            }
            
            catch (Exception )
            {
                return null;
            }
            //return customer;
        }
        public CustomerLoan GetLoanDetails(int customerId)
        {
            try
            {
                return CustomerDbHelper.customersLoan.Find(x => x.CustomerId == customerId);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ApplyLoanResponse ApplyLoan(ApplyLoanRequest applyLoan)
        {
            var loanStatus = new ApplyLoanResponse();
            try
            {
                Customer customer = CustomerDbHelper.customers.Find(x => x.CustomerId == applyLoan.customerLoan.CustomerId);
                if (customer != null)
                {
                    using (var context = new CustomerDbContext(options))
                    {
                        var CustomerLoan = new CustomerLoan
                        {
                            CustomerId = applyLoan.customerLoan.CustomerId,
                            EmploymentType = applyLoan.customerLoan.EmploymentType,
                            LoanType = applyLoan.customerLoan.LoanType,
                            LoanAmount = applyLoan.customerLoan.LoanAmount,
                            Tenure = applyLoan.customerLoan.Tenure

                        };
                        context.customerLoans.Add(CustomerLoan);
                        context.SaveChanges();
                        CustomerDbHelper.customersLoan.Add(CustomerLoan);
                    }

                    loanStatus.CustomerId = applyLoan.customerLoan.CustomerId;
                    loanStatus.LoanStatus = "Applied Successfully";

                }
            }
            catch (Exception e)
            {
                loanStatus.LoanStatus = e.Message;
            }
            return loanStatus;
        }
        public LoanStatusResponse AproveRejectLoan(LoanStatusRequest loanStatusRequest)
        {
            LoanStatusResponse loanStatusResponse = new LoanStatusResponse();
            try
            {
                Customer customer = CustomerDbHelper.customers.Find(x => x.CustomerId == loanStatusRequest.LoanStatus.CustomerId);
                if (customer != null)
                {
                    using (var context = new CustomerDbContext(options))
                    {
                        var status = new LoanStatus
                        {
                            CustomerId = loanStatusRequest.LoanStatus.CustomerId,
                            Status= loanStatusRequest.LoanStatus.Status,
                            Reason= loanStatusRequest.LoanStatus.Reason,
                        };
                        context.LoanStatus.Add(status);
                        context.SaveChanges();
                        CustomerDbHelper.LoanStatus.Add(status);
                    }

                    loanStatusResponse.CustomerId= loanStatusRequest.LoanStatus.CustomerId;
                    loanStatusResponse.Status = "Created Sucessfully";

                }
            }
            catch (Exception e)
            {
                loanStatusResponse.CustomerId = loanStatusRequest.LoanStatus.CustomerId;
                loanStatusResponse.Status=  e.Message;
            }
            return loanStatusResponse;
            
        }

        public LoanStatus GetLoanSatus(int customerId)
        {
            try
            {
                return CustomerDbHelper.LoanStatus.LastOrDefault(x => x.CustomerId == customerId);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
