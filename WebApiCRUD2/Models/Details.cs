using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCRUD2.Models
{
    public class Details
    {
        public Response GetEmployees(SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tbl_clients", connection);

            DataTable dataTable = new DataTable();

            List<Employee> ListEmployee = new List<Employee>();

            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dataTable.Rows[i]["id"]);

                    employee.Name = Convert.ToString(dataTable.Rows[i]["name"]);

                    employee.Email = Convert.ToString(dataTable.Rows[i]["email"]);

                    employee.IsActive = Convert.ToInt32(dataTable.Rows[i]["IsActive"]);

                    ListEmployee.Add(employee);

                }
            }

            if (ListEmployee.Count > 0)
            {
                response.StatusCode = 200;

                response.StetusMsg = "Data found";

                response.ListEmployee = ListEmployee;
            }
            else
            {
                response.StatusCode = 100;

                response.StetusMsg = "Data not found!!!";

                response.ListEmployee = null;   
            }

            return response;
        }

        public Response GetEmployeeById(SqlConnection connection , int id)
        {
            Response response = new Response();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tbl_clients where id ='"+ id +"'and IsActive = 1 ", connection);

            DataTable dataTable = new DataTable();

            Employee Employees = new Employee();

            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dataTable.Rows[0]["id"]);

                    employee.Name = Convert.ToString(dataTable.Rows[0]["name"]);

                    employee.Email = Convert.ToString(dataTable.Rows[0]["email"]);

                    employee.IsActive = Convert.ToInt32(dataTable.Rows[0]["IsActive"]);

                    response.StatusCode = 200;

                    response.StetusMsg = "Data found";

                    response.Employee = employee;

            }
            else
            {
                response.StatusCode = 100;

                response.StetusMsg = "Data not found!!!";

                response.Employee = null;
            }

            return response;
        }

        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand command = new SqlCommand("INSERT INTO tbl_clients(id,name,email,IsActive) VALUES('"+ employee.Id+ "','" + employee.Name + "','" + employee.Email + "','" + employee.IsActive + "')", connection);

            //SUPPOSE WE USE AN GET DATE() FUNCTION:

            //SqlDataAdapter dataAdapter = new SqlDataAdapter("INSERT INTO tbl_clients(id,name,email,IsActive) VALUES('" + employee.Id + "','" + employee.Name + "','" + employee.Email + "','" + employee.IsActive + "',GETDATE())", connection);

            connection.Open();

            int i = command.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;

                response.StetusMsg = "Employee added.";

            }
            else
            {
                response.StatusCode = 100;

                response.StetusMsg = "No data inserted.";

            }

            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand command = new SqlCommand("UPDATE tbl_clients SET id = '" + employee.Id + "',name = '" + employee.Name + "',email = '" + employee.Email + "',IsActive = '" + employee.IsActive + "' WHERE id = '"+employee.Id+"' ",connection);
          
            connection.Open();

            int i = command.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;

                response.StetusMsg = "Employee updated.";

            }
            else
            {
                response.StatusCode = 100;

                response.StetusMsg = "No data updated.";

            }

            return response;
        }

        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();

            SqlCommand command = new SqlCommand("DELETE FROM tbl_clients WHERE id = '"+ id +"' ",connection);

            connection.Open();

            int i = command.ExecuteNonQuery();

            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;

                response.StetusMsg = "Employee deleted.";

            }
            else
            {
                response.StatusCode = 100;

                response.StetusMsg = "No employee deleted.";

            }

            return response;
        }
    }
}
