using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.DAL.Responses
{
    public class ApplyLoanResponse
    {
        public int CustomerId { get; set; }

        public string LoanStatus { get; set; }
    }
}
