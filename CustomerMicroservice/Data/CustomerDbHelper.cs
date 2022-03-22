using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Data
{
    public static class CustomerDbHelper
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){CustomerId = 1000, FirstName = "Tuhina", LastName = "Pal", Address = "Mumbai", DateOfBirth = new DateTime(1999,02,02), PanNumber = "MFPFS10001A", Password = "ABC123" },
            new Customer(){CustomerId = 1001, FirstName = "Ali", LastName = "Idrush", Address = "Mumbai", DateOfBirth = new DateTime(1998,07,20), PanNumber = "MFPFS10002B", Password = "ABC1234" },
            new Customer(){CustomerId = 1002, FirstName = "Bhagyashree", LastName = "k", Address = "Chennai", DateOfBirth = new DateTime(1998,04,15), PanNumber = "MFPFS10003C", Password = "ABC12345" },
            new Customer(){CustomerId = 1003, FirstName = "Dolon", LastName = "Ghanty", Address = "Erode", DateOfBirth = new DateTime(1998,08,25), PanNumber = "MFPFS10004B", Password = "ABC123456" }
        };

        public static List<CustomerLoan> customersLoan = new List<CustomerLoan>()
        {
            new CustomerLoan(){CustomerId = 1000,LoanAmount =200000,Tenure=5,EmploymentType="Private",LoanType="Home Loan" },
            new CustomerLoan(){CustomerId = 1001, LoanAmount =500000,Tenure=10,EmploymentType="Business",LoanType="Business Loan" },
            new CustomerLoan(){CustomerId = 1002, LoanAmount =300000,Tenure=6,EmploymentType="Government",LoanType="Car Loan" },
            new CustomerLoan(){CustomerId = 1003, LoanAmount =100000,Tenure=15,EmploymentType="Private",LoanType="Education Loan" }
        };
        public static List<LoanStatus> LoanStatus = new List<LoanStatus>()
        {
            new LoanStatus(){CustomerId=1000,Status="Approved",Reason="Contact our Branch for further process."},
            new LoanStatus(){CustomerId=1001,Status="Rejected",Reason="Chosen Tenure does not comply with us"}
        };
    }
}
