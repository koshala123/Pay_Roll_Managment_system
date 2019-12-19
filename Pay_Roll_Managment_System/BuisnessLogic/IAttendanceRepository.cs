using Pay_Roll_Managment_System.Dtos;
using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IAttendanceRepository
    {
        ICollection<Attendance> GetAttendances();
        Attendance GetAttendance(int AttendanceId);
        bool AttendanceExsists(int AttendanceId);
        bool CreateAttendance(AttendanceDto Attendance);
        bool UpdateAttendance(AttendanceDto Attendance);
        bool Save();

    }
}
