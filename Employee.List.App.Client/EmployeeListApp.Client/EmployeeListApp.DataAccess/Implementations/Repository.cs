using EmployeeListApp.DataAccess.Context;
using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchPattern)
        {
            var employees = await _context.Employees
               .FromSqlRaw("EXEC sp_SearchEmployees @p0", searchPattern)
               .ToListAsync();

            return employees;
        }
    }
}
