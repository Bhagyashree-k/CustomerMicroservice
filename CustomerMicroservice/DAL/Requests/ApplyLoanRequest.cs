using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.DAL.Requests
{
    public class ApplyLoanRequest
    {
        public CustomerLoan customerLoan { get; set; }
    }
}
