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
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _EmployeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository )
        {
            _EmployeeRepository = employeeRepository;
        }

        //api/Employees/EmployeeId
        [HttpGet("{EmployeeId}", Name = "GetEmployee")]
        [ProducesResponseType(200, Type = typeof(EmployeeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetEmployee(int EmployeeId)
        {
            if (! _EmployeeRepository.EmployeeExists(EmployeeId) )
            {
                return NotFound("Employee doesn't exsist");
            }
            var Employee = _EmployeeRepository.GetEmployee(EmployeeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var EmployeeDto = new EmployeeDto
            {
                Id =Employee.EmployeeId,
                RegistrationNo = Employee.RegistrationNo,
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                Gender = Employee.Gender,
                CreatedOn = Employee.CreatedOn,
                Address = Employee.Address,
                ContactInfo = Employee.ContactInfo
            };
            return Ok(EmployeeDto);
        }

        //api/Employees
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDto>))]

        public IActionResult GetEmployees() 
        {
            var Employees = _EmployeeRepository.GetEmployees();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var EmployeeDto = new List<EmployeeDto>();

            foreach (var Employee in Employees)
            {
                EmployeeDto.Add(new EmployeeDto 
                {
                    Id = Employee.EmployeeId,
                    RegistrationNo = Employee.RegistrationNo,
                    FirstName = Employee.FirstName,
                    LastName = Employee.LastName,
                    Gender = Employee.Gender,
                    CreatedOn = Employee.CreatedOn,
                    Address = Employee.Address,
                    ContactInfo = Employee.ContactInfo
                });                
            }
            return Ok(EmployeeDto);
        }

        //api/Employees
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult CreateEmpoyee([FromBody]Employee EmployeeToCreate)
        {
            if (EmployeeToCreate ==null)
            {
                return BadRequest(ModelState);
            }

            //Checking the method of Employee forign key. 2 if conditions have to be satisified

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //creating employee
            if (!_EmployeeRepository.CreateEmployee(EmployeeToCreate))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetEmployee", new { EmployeeId = EmployeeToCreate.EmployeeId }, EmployeeToCreate);

        }

        //api/Employees/EmployeeId
        [HttpPut("{EmployeeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult UpdatEmployee (int EmployeeId ,[FromBody]Employee EmployeeToUpdate)
        {
            if (EmployeeToUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (EmployeeId != EmployeeToUpdate.EmployeeId)
            {
                return BadRequest(ModelState);
            }

            if (!_EmployeeRepository.EmployeeExists(EmployeeId))
            {
                ModelState.AddModelError("", "Employee Doesn't Exsist.");
            }

            // cheking of forign key 1 if conidtion

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // updating part

            if (!_EmployeeRepository.UpdateEmployee(EmployeeToUpdate))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //api/Employees/EmployeeId
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [HttpDelete("{EmployeeId}")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            if (!_EmployeeRepository.EmployeeExists(EmployeeId))
            {
                return NotFound();
            }
            var EmployeeToDelte = _EmployeeRepository.GetEmployee(EmployeeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_EmployeeRepository.DeleteEmployee(EmployeeToDelte))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}