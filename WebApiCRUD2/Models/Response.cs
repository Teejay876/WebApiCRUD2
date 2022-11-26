using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCRUD2.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string StetusMsg { get; set; }

        public Employee Employee { get; set; }

        public List<Employee> ListEmployee { get; set; }
    }
}
