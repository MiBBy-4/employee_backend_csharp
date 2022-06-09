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
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration __configuration;

        public EmployeeController(IConfiguration configuration)
        {
            __configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string getQuery = @"select employee_id, employee_name, convert(varchar(10), date_of_joining, 120) as date_of_joining, photo_file_name, department_id from Employee";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee data)
        {
            string getQuery = $@"insert into Employee values('{data.employee_name}', '{data.date_of_joining}','{data.photo_file_name}', '{data.depatrment_id}');";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee data)
        {
            string getQuery = $@"update Employee set employee_name = '{data.employee_name}', date_of_joining = '{data.date_of_joining}', photo_file_name = '{data.photo_file_name}', department_id = {data.depatrment_id} where employee_id = '{data.employee_id}'";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string getQuery = $@"delete from Employee where employee_id = {id}";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult Show(int id)
        {
            string getQuery = $@"select * from Employee where employee_id = '{id}'";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
