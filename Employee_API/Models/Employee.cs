using System.Data;
using System.Data.SqlClient;

namespace Employee_API.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string date_of_joining { get; set; }
        public int department_id { get; set; }

        static public DataTable all(IConfiguration _configuration)
        {
            string getQuery = @"select e.employee_id, e.employee_name, convert(varchar(10), e.date_of_joining, 120) as date_of_joining, d.department_name from Employee e join Department d on d.department_id = e.department_id;";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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

            return table;
        }

        static public DataTable create(Employee data, IConfiguration _configuration)
        {
            string getQuery = $@"insert into Employee values('{data.employee_name}', '{data.date_of_joining}', '{data.department_id}');";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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

            return table;
        }

        static public DataTable update(Employee data, IConfiguration _configuration)
        {
            string getQuery = $@"update Employee set employee_name = '{data.employee_name}', date_of_joining = '{data.date_of_joining}', department_id = {data.department_id} where employee_id = '{data.employee_id}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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

            return table;
        }

        static public DataTable destroy(int id, IConfiguration _configuration)
        {
            string getQuery = $@"delete from Employee where employee_id = {id}";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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

            return table;
        }

        static public DataTable find(int id, IConfiguration _configuration)
        {
            string getQuery = $@"select * from Employee where employee_id = '{id}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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

            return table;
        }
    }

}
