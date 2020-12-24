using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoMG.Models;
using ProyectoMG.Service;
using ProyectoMG.DTO;

namespace ProyectoMG.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private EmployeesService employeesService;

        public EmployeeController()
        {
            employeesService = new EmployeesService();
        }

        [HttpGet("[action]")]
        public IEnumerable<EmployeeDTO> GetEmployees(int employeeId)
        {
            var employees = employeesService.Search(employeeId);

            return employees;
        }
    }
}
