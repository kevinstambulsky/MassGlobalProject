using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ProyectoMG.Models;
using Newtonsoft.Json;

namespace ProyectoMG.Repository
{
    public class EmployeesRepository
    {
        static HttpClient client = new HttpClient();
        static Uri BaseAdress = new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees");
       
        public List<Employee> GetEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                if (client.BaseAddress == null)
                    client.BaseAddress = BaseAdress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                }

                return employees;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
