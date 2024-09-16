using EmployeeListApp.DataAccess.Context;
using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Repository;

namespace EmployeeListApp.DataAccess.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) 
        {
            
        }
    }
}
