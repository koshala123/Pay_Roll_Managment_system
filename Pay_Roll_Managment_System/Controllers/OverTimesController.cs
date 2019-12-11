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
    public class OverTimesController : ControllerBase
    {
        private IOverTimeRepository _OverTimeRepository;
        public OverTimesController(IOverTimeRepository OverTimeRepository)
        {
            _OverTimeRepository = OverTimeRepository;
        }

        //api/OverTimes/OverTimesId
        [HttpGet("{OverTImeId}", Name = "GetOverTime")]
        [ProducesResponseType(200, Type = typeof(OverTime))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        
        public IActionResult GetOverTime(int OverTimeId)
        {
            if (!_OverTimeRepository.OverTimeExsist(OverTimeId))
            {
                return NotFound("Over Time Doesn't Exsist");
            }

            var OverTime = _OverTimeRepository.GetOverTime(OverTimeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(OverTime);
        }

        //api/OverTImes
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OverTime>))]
        public IActionResult GetOverTimes()
        {
            var OverTimes = _OverTimeRepository.GetOverTimes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(OverTimes);
        }

        //api/OverTimes
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OverTime))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult CreateOverTime ([FromBody]OverTime OverTimeToCreate)
        {
            if (OverTimeToCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_OverTimeRepository.CreateOverTime(OverTimeToCreate))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetOverTime", new { OverTimeId = OverTimeToCreate.OverTimeId }, OverTimeToCreate);
        }

        //api/OverTImes/OverTimeId
        [HttpPut("{OverTimeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult UpdateOverTime (int OverTimeId , [FromBody]OverTime OverTimeToUpdate)
        {
            if (OverTimeToUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (OverTimeId != OverTimeToUpdate.OverTimeId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_OverTimeRepository.UpdateOverTime(OverTimeToUpdate))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}