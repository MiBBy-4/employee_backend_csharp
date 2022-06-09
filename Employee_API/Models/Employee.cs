namespace Employee_API.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string date_of_joining { get; set; }
        public string photo_file_name { get; set; }
        public int depatrment_id { get; set; }
    }
}
