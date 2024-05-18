using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Repository
{
    public interface IRepository<out T> where T : DomainObject
    {
        T Get(int id);
    }
    public interface IEmployeeRepository: IRepository<Employeee>
    {

    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public Employeee Get(int id)
        {
            return Employee.Find(e =>  e.Id == id);
        }
    }
}
