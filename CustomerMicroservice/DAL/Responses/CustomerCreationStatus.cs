using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class CustomerCreationStatus
    {
        public int CustomerId { get; set; }

        public string Status { get; set; }
    }
}
