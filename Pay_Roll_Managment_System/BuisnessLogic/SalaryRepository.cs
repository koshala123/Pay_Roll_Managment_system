using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class SalaryRepository : ISalaryRepository
    {
        PayRollManagmentContext _PayRollManagmentContext;
        public SalaryRepository(PayRollManagmentContext PayRollManagmentContext)
        {
            _PayRollManagmentContext = PayRollManagmentContext;
        }
        public bool CreateSalary(Salary Salary)
        {
            _PayRollManagmentContext.Add(Salary);
            return Save();
        }

        public bool DeleteSalary(Salary salary)
        {
            _PayRollManagmentContext.Salaries.Remove(salary);
            return Save();
        }

        public ICollection<Salary> GetSalaries()
        {
            return _PayRollManagmentContext.Salaries.OrderBy(a => a.SalaryId).ToList();
        }

        public Salary GetSalary(int SalaryId)
        {
            return _PayRollManagmentContext.Salaries.Where(a => a.SalaryId == SalaryId).FirstOrDefault();
        }

        public bool SalaryExsists(int SalaryId)
        {
           return _PayRollManagmentContext.Salaries.Any(a => a.SalaryId == SalaryId);
        }

        public bool Save()
        {
            var save = _PayRollManagmentContext.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateSalary(Salary Salary)
        {
            _PayRollManagmentContext.Salaries.Update(Salary);
            return Save();
        }
    }
}
