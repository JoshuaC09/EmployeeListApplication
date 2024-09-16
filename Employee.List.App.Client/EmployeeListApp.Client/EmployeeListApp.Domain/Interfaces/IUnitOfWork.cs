namespace EmployeeListApp.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> SaveAsync();
    }
}
