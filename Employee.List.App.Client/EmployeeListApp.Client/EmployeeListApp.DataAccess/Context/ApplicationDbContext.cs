using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
        public DbSet<Employee> Employees {  get; set; }

        // Seed data or initial value for testing

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Test1",
                    LastName = "Test1",
                    MiddleName = "Test1",
                    Email = "Test1@gmail.com",
                    Address = "Santa Maria, Bulacan",
                    PhoneNumber = "09503334244",
                    Salary = 12000,
                    Gender = EmployeeGender.Male,
                    Status = EmployeeStatus.Active
                },
                 new Employee
                 {
                     EmployeeId = 2,
                     FirstName = "Test2",
                     LastName = "Test2",
                     MiddleName = "Test2",
                     Email = "Test2@gmail.com",
                     Address = "Santa Maria, Bulacan",
                     PhoneNumber = "095055635412",
                     Salary = 13000,
                     Gender = EmployeeGender.Male,
                     Status = EmployeeStatus.Active
                 },
                 new Employee
                    {
                        EmployeeId = 3,
                        FirstName = "Test3",
                        LastName = "Test3",
                        MiddleName = "Test3",
                        Email = "Test3@gmail.com",
                        Address = "Santa Maria, Bulacan",
                        PhoneNumber = "09505433362",
                        Salary = 14000,
                        Gender = EmployeeGender.Female,
                        Status = EmployeeStatus.InActive
                    }

                );
        }
    }
}
