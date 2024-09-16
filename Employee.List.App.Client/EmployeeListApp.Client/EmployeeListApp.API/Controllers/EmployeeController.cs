using EmployeeListApp.Domain.Entities;
using EmployeeListApp.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            IEnumerable<Employee> employeeFromRepository = await _unitOfWork.EmployeeRepository.GetAllAsync();
            return Ok(employeeFromRepository);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }
            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            if (id == 0)
            {
                return NotFound();
            }
            await _unitOfWork.EmployeeRepository.UpdateAsync(updatedEmployee);
            await _unitOfWork.SaveAsync();
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

            [HttpGet("search")]
            public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees([FromQuery] string searchPattern)
            {
                var employees = await _unitOfWork.EmployeeRepository.SearchEmployeesAsync(searchPattern);
                return Ok(employees);
            }
    }
}
        