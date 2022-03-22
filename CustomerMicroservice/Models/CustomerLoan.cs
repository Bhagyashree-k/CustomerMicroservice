using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class CustomerLoan
    {
        [Key]
        public int CustomerId { get; set; }
        public int LoanAmount { get; set; }
        public int Tenure { get; set; }
        public string LoanType { get; set; }
        public string EmploymentType { get; set; }

    }
}
