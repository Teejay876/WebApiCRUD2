using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD2.Models;
using System.Data.SqlClient;

namespace WebApiCRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetEmployees")]

        public Response GetEmployees()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDoperation").ToString());

            Response response = new Response();

            Details details = new Details();

            response = details.GetEmployees(connection);

            return response;
        }

        [HttpGet]
        [Route("GetEmployeeById /{id}")]

        public Response GetEmployeeById( int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDoperation").ToString());

            Response response = new Response();

            Details details = new Details();

            response = details.GetEmployeeById(connection,id);

            return response;
        }

        [HttpPost]
        [Route("AddEmployee")]

        public Response AddEmployee(Employee employee)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDoperation").ToString());

            Response response = new Response();

            Details details = new Details();

            response = details.AddEmployee(connection,employee);

            return response;
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public Response UpdateEmployee(Employee employee)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDoperation").ToString());

            Response response = new Response();

            Details details = new Details();

            response = details.UpdateEmployee(connection, employee);

            return response;
        }

        [HttpDelete]
        [Route("DeleteEmployee / {id}")]

        public Response DeleteEmployee(int id)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CRUDoperation").ToString());

            Response response = new Response();

            Details details = new Details();

            response = details.DeleteEmployee(connection, id);

            return response;
        }
    }
}
