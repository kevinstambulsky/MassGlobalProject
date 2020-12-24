﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoMG.DTO;
using ProyectoMG.Models;

namespace ProyectoMG.Service
{
    public class MonthlyContractFactory
    {
        public EmployeeDTO GetEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                anualSalary = employee.monthlySalary * 12,
                id = employee.id,
                name = employee.name,
                contractTypeName = employee.contractTypeName,
                hourlySalary = employee.hourlySalary,
                monthlySalary = employee.monthlySalary,
                roleDescription = employee.roleDescription == "" ? employee.roleDescription : "-",
                roleId = employee.roleId,
                roleName = employee.roleName
            };

            return employeeDTO;

        }
    }
}