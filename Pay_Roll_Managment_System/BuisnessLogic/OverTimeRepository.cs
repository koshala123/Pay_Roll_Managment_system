using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class OverTimeRepository : IOverTimeRepository
    {
        private PayRollManagmentContext _PayRollManagmentContext;
        public OverTimeRepository(PayRollManagmentContext payRollManagmentContext)
        {
            _PayRollManagmentContext = payRollManagmentContext;
        }
        public bool CreateOverTime(OverTime OverTime)
        {
            _PayRollManagmentContext.Add(OverTime);
            return Save();
        }

        public OverTime GetOverTime(int OverTimeId)
        {
            return _PayRollManagmentContext.OverTimes.Where(a => a.OverTimeId == OverTimeId).FirstOrDefault();
        }

        public ICollection<OverTime> GetOverTimes()
        {
            return _PayRollManagmentContext.OverTimes.OrderBy(a => a.OverTimeId).ToList();
        }

        public bool OverTimeExsist(int OverTimeId)
        {
            return _PayRollManagmentContext.OverTimes.Any(a => a.OverTimeId == OverTimeId);
        }

        public bool Save()
        {
            var saved = _PayRollManagmentContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateOverTime(OverTime OverTime)
        {
            _PayRollManagmentContext.Update(OverTime);
            return Save();
        }
    }
}
