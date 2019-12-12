using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IOverTimeRepository
    {
        ICollection<OverTime> GetOverTimes();
        OverTime GetOverTime(int OverTimeId);
        bool OverTimeExsist(int OverTimeId);
        bool CreateOverTime(OverTime OverTime);
        bool UpdateOverTime(OverTime OverTime);
        bool Save();
    }
}
