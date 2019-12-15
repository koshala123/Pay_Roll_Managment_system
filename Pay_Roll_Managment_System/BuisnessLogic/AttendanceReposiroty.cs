using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class AttendanceReposiroty : IAttendanceRepository
    {
        private PayRollManagmentContext _PayRollManagmentContext;
        public AttendanceReposiroty(PayRollManagmentContext PayRollManagmentContext)
        {
            _PayRollManagmentContext = PayRollManagmentContext;
        }
        public bool AttendanceExsists(int AttendanceId)
        {
            return _PayRollManagmentContext.Attendances.Any(a => a.AttendanceId == AttendanceId);
        }

        public bool CreateAttendance(Attendance Attendance)
        {
            _PayRollManagmentContext.Attendances.Add(Attendance);
            return Save();
        }

        public Attendance GetAttendance(int AttendanceId)
        {
            return _PayRollManagmentContext.Attendances.Where(a => a.AttendanceId == AttendanceId).FirstOrDefault();
        }

        public ICollection<Attendance> GetAttendances()
        {
            return _PayRollManagmentContext.Attendances.OrderBy(a => a.AttendanceId).ToList();
        }

        public bool Save()
        {
            var save =_PayRollManagmentContext.SaveChanges();
            return save >= 0 ? true : false;
        }
        public bool UpdateAttendance(Attendance Attendance)
        {
            _PayRollManagmentContext.Update(Attendance);
            return Save();
        }
    }
}
