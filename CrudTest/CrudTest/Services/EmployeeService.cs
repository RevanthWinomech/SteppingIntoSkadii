using CrudTest.Data;
using CrudTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Services
{
    public class EmployeeService
    {

   
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeService(EmployeeDbContext employeeDbContext)
        { 
            _employeeDbContext=employeeDbContext;
        }


        // post employee
         
        public async Task AddEmployee(Employee employeeRequest)
        {
            var employee = new Employee
            {

                EmployeeName = employeeRequest.EmployeeName,
                EmployeeId = employeeRequest.EmployeeId,
                EmployeeDept = employeeRequest.EmployeeDept

            };

            _employeeDbContext.Employees.Add(employee);
            await _employeeDbContext.SaveChangesAsync();
        }

        // get employee latest

        public async Task<Employee?> GetEmployeeAsync()
        {
            return await _employeeDbContext.Employees
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

    }
}
