using EmployeeApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
