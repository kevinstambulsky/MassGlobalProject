using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoMG.Repository;
using ProyectoMG.Models;
using ProyectoMG.DTO;

namespace ProyectoMG.Service
{
    public class EmployeesService
    {
        private EmployeesRepository repo;
        private HourlyContractFactory hf;
        private MonthlyContractFactory mf;

        public EmployeesService()
        {
            repo = new EmployeesRepository();
            hf = new HourlyContractFactory();
            mf = new MonthlyContractFactory();
        }

        public List<EmployeeDTO> Search(int employeeId)
        {
            List<Employee> employees = new List<Employee>();
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();

            employees = repo.GetEmployees();

            if (employeeId != 0)
                employees = employees.Where(x => x.id == employeeId).ToList();

            foreach (var item in employees)
            {
                switch (item.contractTypeName)
                {
                    case "MonthlySalaryEmployee":
                        employeesDTO.Add(mf.GetEmployeeDTO(item));
                        break;
                    case "HourlySalaryEmployee":
                        employeesDTO.Add(hf.GetEmployeeDTO(item));
                        break;
                }
            }

            return employeesDTO;
        }
    }
}
