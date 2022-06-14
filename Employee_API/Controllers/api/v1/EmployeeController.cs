using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Employee_API.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Employee_API.Controllers.api.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable employees = Employee.all(_configuration); 
            return new JsonResult(employees);
        }

        [HttpPost]
        public JsonResult Post(Employee data)
        {
            DataTable employee = Employee.create(data, _configuration);
            return new JsonResult(employee);
        }

        [HttpPatch]
        public JsonResult Patch(Employee data)
        {
            DataTable employee = Employee.update(data, _configuration);
            return new JsonResult(employee);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Employee.destroy(id, _configuration);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult Show(int id)
        {
            DataTable employee = Employee.find(id, _configuration);
            return new JsonResult(employee);
        }

        [Route("GetAllDepartmentNames")]
        [HttpGet]
        public JsonResult GetAllDepartmentNames()
        {
            DataTable departments = Department.allNames(_configuration);
            return new JsonResult(departments);
        }
    }
}
