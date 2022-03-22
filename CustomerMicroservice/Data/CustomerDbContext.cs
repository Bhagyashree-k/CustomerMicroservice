using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
       : base(options)
        {

        }
       
        public DbSet<CustomerLoan> customerLoans { get; set; }
        public DbSet<LoanStatus> LoanStatus { get; set; }
        //public DbSet<Customer> customers { get; set; }
    }
}
