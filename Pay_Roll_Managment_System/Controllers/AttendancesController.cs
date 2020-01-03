using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay_Roll_Managment_System.BuisnessLogic;
using Pay_Roll_Managment_System.Dtos;
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
        public IActionResult CreateAttendance ([FromBody]AttendanceDto Attendance)
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
            return NoContent();
        }

        [HttpPut/*("{AttendanceId}")*/]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateAttendance (/*int AttendanceId,*/[FromBody]AttendanceDto attendanceToUpdate)
        {
            if (attendanceToUpdate == null)
            {
                return BadRequest(ModelState);
            }
            /*if (!_AttendanceRepository.AttendanceExsists(AttendanceId))
            {
                ModelState.AddModelError("","Salary Doesn't Exsist");
            }*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_AttendanceRepository.UpdateAttendance(attendanceToUpdate))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}