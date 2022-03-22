using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Models
{
    public class LoanStatus
    {
        [Key]
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }

    }
}
