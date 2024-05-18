using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class DomainObject
    {
    }

    public class Employeee : DomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime JoiningDate {  get; set; }

        public double Salary {  get; set; }
        
    }
}
