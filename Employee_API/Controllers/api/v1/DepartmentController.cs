using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Employee_API.Models;

namespace Employee_API.Controllers.api.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration __configuration;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IConfiguration configuration, IWebHostEnvironment env)
        {
            __configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
           DataTable departments = Department.all(__configuration);
            return new JsonResult(departments);
        }

        [HttpPost]
        public JsonResult Post(Department data)
        {
            DataTable departments = Department.create(data, __configuration);
            return new JsonResult(departments);
        }

        [HttpPatch]
        public JsonResult Patch(Department data)
        {
            DataTable departments = Department.update(data, __configuration);
            return new JsonResult(departments);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            DataTable departments = Department.destroy(id, __configuration);
            return new JsonResult(departments);
        }

        [HttpGet("{id}")]
        public JsonResult Show(int id)
        {
            DataTable departments = Department.find(id, __configuration);
            return new JsonResult(departments);
        }

        [Route("GetEmployees/{id}")]
        [HttpGet]
        public JsonResult getEmployees(int id)
        {
            DataTable employees = Department.employees(id, __configuration);
            return new JsonResult(employees);
        }
    }
}
