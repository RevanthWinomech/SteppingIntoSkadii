using CrudTest.Data;
using CrudTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }




    }
}
