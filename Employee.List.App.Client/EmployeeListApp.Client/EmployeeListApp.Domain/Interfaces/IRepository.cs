using EmployeeListApp.Domain.Entities;

namespace EmployeeListApp.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchPattern);
    }
}
