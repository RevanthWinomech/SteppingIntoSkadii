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

            _employeeDbContext.Employees.Add(employeeRequest);
            await _employeeDbContext.SaveChangesAsync();
        }

        //get all employees

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeDbContext.Employees.ToListAsync();

        }

        //get by id

        public async Task<Employee> GetEmployeeById(int EmployeeId)
        {
            return await _employeeDbContext.Employees.FindAsync(EmployeeId);
           
        }

        // get employee latest

        public async Task<Employee?> GetEmployeeAsync()
        {
            return await _employeeDbContext.Employees
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

        //update employee
        
        public async Task<bool> UpdateEmployee(int EmployeeId, Employee employee)
        {
            var updated = await _employeeDbContext.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);

            if (updated == null)
            {
                return false;
            }

            updated.EmployeeName = employee.EmployeeName;
            updated.EmployeeDept = employee.EmployeeDept;

            await _employeeDbContext.SaveChangesAsync();

            return true;
        }

        //delete employee

        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(EmployeeId);

            if (employee == null)
                return false;

            _employeeDbContext.Employees.Remove(employee);
            await _employeeDbContext.SaveChangesAsync();

            return true;
        }





    }
}
