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


        [HttpPost]

        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _employeeService.AddEmployee(employee);
            return Ok("employee added");
        }

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



    }
}
