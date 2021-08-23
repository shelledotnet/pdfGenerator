
using PdfGenerator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfGenerator.API.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployee() =>
        new List<Employee>
        {
            new Employee{ Name="Sheu",LastName="Adamo", Age=34,Gender="Male"},
             new Employee{ Name="Shetimah",LastName="usman", Age=34,Gender="Female"},
              new Employee{ Name="Sheu",LastName="Adamo", Age=34,Gender="Male"}
        };
    }
}
