using EmployeeApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        double CalculateTax( int employeeId, DateTime to );
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ITaxservice _taxservice;
        private IEmployeeRepository _repository;
        public EmployeeService(ITaxservice taxservice, IEmployeeRepository repository) {

            _taxservice = taxservice;
            _repository = repository;   
        }
        public double CalculateTax(int employeeId, DateTime to)
        {
            var employee = _repository.Get(employeeId);
            var TotalMonth = ((to - employee.JoiningDate).TotalDays + 1) / 30;
            var TotalSalary= TotalMonth * employee.Salary;
            return TotalSalary* _taxservice.GetTaxRate();
        }
    }

    public interface ITaxservice
    {
        double GetTaxRate();
    }

    public class TaxService: ITaxservice
    {
        const double _taxRate = 0.015;

        public double GetTaxRate()
        {
            return _taxRate;
        }
    }
}
