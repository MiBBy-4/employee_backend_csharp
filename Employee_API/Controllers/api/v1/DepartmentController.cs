﻿using Microsoft.AspNetCore.Http;
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

        public DepartmentController(IConfiguration configuration)
        {
            __configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string getQuery = @"select * from Department";
            DataTable table = new DataTable();
            string sqlDataSource = __configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader sqlReader;
            using(SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(getQuery, sqlConnection))
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
        public JsonResult Post(Department data)
        {
            string getQuery = $@"insert into Department values ('{data.department_name}')";
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
    }
}