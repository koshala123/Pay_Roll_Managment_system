using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay_Roll_Managment_System.BuisnessLogic;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private IAttendanceRepository _AttendanceRepository;
        public AttendancesController(IAttendanceRepository AttendanceRepository)
        {
            _AttendanceRepository = AttendanceRepository;
        }

        //api/Attendances/AttendanceId
        [HttpGet("{AttendanceId}", Name = "GetAttendance")]
        [ProducesResponseType(200, Type = typeof(Attendance))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAttendance(int AttendanceId)
        {
            if (!_AttendanceRepository.AttendanceExsists(AttendanceId))
            {
                return NotFound("Attendace Does Not Exsist");
            }

            var Attendance = _AttendanceRepository.GetAttendance(AttendanceId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Attendance);
        }

        //api/Attendances
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Attendance>))]
        public IActionResult GetAttendances()
        {
            var Attendances = _AttendanceRepository.GetAttendances();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Attendances);
        }

        //api/attendances
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Attendance))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateAttendance ([FromBody]Attendance Attendance)
        {
            if (Attendance == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_AttendanceRepository.CreateAttendance(Attendance))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetAttendance", new { AttendanceId = Attendance.AttendanceId }, Attendance);
        }
    }
}