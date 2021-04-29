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
        /*public IEnumerable<Employee> Get()
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
        }*/
        public HttpResponseMessage Get()
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                var Employees = dbContext.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, Employees);
            }
        }
        public IHttpActionResult Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Ok(entity);
                }
                else
                {
                    //return NotFound();
                    //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID " + id.ToString() + "not found"));
                    //see https://www.infoworld.com/article/2994111/how-to-handle-errors-in-aspnet-web-api.html
                    return ResponseMessage(
                            Request.CreateResponse(
                                HttpStatusCode.NotFound,
                                "Employee with ID " + id.ToString() + " not found"
                            )
                        );
                    //see https://stackoverflow.com/questions/20139621/how-do-i-return-notfound-ihttpactionresult-with-an-error-message-or-exception
                }
            }
        }
    }
}
