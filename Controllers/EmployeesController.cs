using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebAPIDemo.Models;

namespace FirstWebAPIDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.FirstOrDefault(e => e.ID == id);
            }
        }
    }
}
