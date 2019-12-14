using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface ISalaryRepository
    {
        ICollection<Salary> GetSalaries();
        Salary GetSalary(int SalaryId);
        bool SalaryExsists (int SalaryId);
        bool CreateSalary(Salary Salary);
        bool UpdateSalary(Salary Salary);
        bool DeleteSalary(Salary salary);
        bool Save();

    }
}
