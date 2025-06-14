using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.model
{
    public class EmployeeController
    {
        public void AddEmployee(Employee c)
        {
            Employees cls = new Employees();
            cls.AddEmployee(c);
        }
    }
}
