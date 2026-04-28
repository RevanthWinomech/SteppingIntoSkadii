using CrudTest.Data;
using CrudTest.Models;
using CrudTest.Services;
using Microsoft.AspNetCore.Mvc;


namespace CrudTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        //create employee

        [HttpPost]

        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _employeeService.AddEmployee(employee);
            return Ok("employee added");
        }

        //get all employees
        [HttpGet("allEmployees")]

        public async Task<IActionResult> FetchAllEmployees()
        {
            List<Employee> employees=await _employeeService.GetAllEmployees();
            if(employees==null || employees.Count == 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        //get employee by id
        [HttpGet("{EmployeeId}")]

        public async Task<IActionResult> FetchById(int EmployeeId)
        {
             var employee= await _employeeService.GetEmployeeById(EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }
        //get latest employee

        [HttpGet]

        public async Task<IActionResult> GetLatestEmployee()
        {
            var emp=await _employeeService.GetEmployeeAsync();

            if(emp==null) 
                {
                return NotFound("no employee found");
                }
            return Ok(emp);
        }

        //update employee
        [HttpPut("update/{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployee(int EmployeeId, [FromBody] Employee employee)
        {
            var updated = await _employeeService.UpdateEmployee(EmployeeId, employee);

            if (updated == null)
            {
                return BadRequest("employee not found");
            }

            return Ok("updated successfully");
        }

        //delete by id

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            var deleted = await _employeeService.DeleteEmployee(EmployeeId);

            if (!deleted)
            {
                return NotFound("Employee not found");
            }

            return Ok("Employee deleted");
        }




    }
}
