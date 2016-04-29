using PagingAndSortingInMvc.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PagingAndSortingInMvc.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
            : base("name=ConnectionString") 
        { }

        public DbSet<EmployeeMaster> Employees { get; set; }
    }
}