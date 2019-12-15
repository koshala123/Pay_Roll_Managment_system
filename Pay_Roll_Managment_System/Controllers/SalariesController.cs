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
    public class SalariesController : ControllerBase
    {
        private ISalaryRepository _SalaryRepository;
        public SalariesController(ISalaryRepository SalaryRepository)
        {
            _SalaryRepository = SalaryRepository;
        }

        //api/Salaries/SalaryId
        [HttpGet("{SalaryId}", Name = "GetSalary")]
        [ProducesResponseType(200, Type = typeof(Salary))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetSalary(int SalaryId)
        {
            if (!_SalaryRepository.SalaryExsists(SalaryId))
            {
                return NotFound("Salary Id Not found");
            }
            var salary = _SalaryRepository.GetSalary(SalaryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(salary);
        }

        //api/salaries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Salary>))]
        public IActionResult GetSalaries()
        {
            var salaries = _SalaryRepository.GetSalaries();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(salaries);
        }

        //api/Salaries
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Salary))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateSalary([FromBody]Salary salary)
        {
            if (salary == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_SalaryRepository.CreateSalary(salary))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetSalary", new { salaryId = salary.SalaryId }, salary);
        }

        //api/salaries/salaryId
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [HttpDelete("{SalaryId}")]
        public IActionResult DeleteSalary(int salaryId)
        {
            if (_SalaryRepository.SalaryExsists(salaryId))
            {
                return NotFound(salaryId);
            }
            var salaryToDelete = _SalaryRepository.GetSalary(salaryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_SalaryRepository.DeleteSalary(salaryToDelete))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //api/authors/authorId
        [HttpPut("{salaryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult UpdateSalary(int salaryId,[FromBody]Salary salaryToUpdate)
        {
            if (salaryToUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (!_SalaryRepository.SalaryExsists(salaryId))
            {
                ModelState.AddModelError("", "Salary doesnt exsist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_SalaryRepository.UpdateSalary(salaryToUpdate))
            {
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}