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
    [Route("api/Positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private IPositionRepository _PositionRepository;
        public PositionsController(IPositionRepository PositionRepository)
        {
            _PositionRepository = PositionRepository;
        }

        //api/positions/positionId
        [HttpGet("{positionId}", Name = "GetPosition")]
        [ProducesResponseType(200, Type = typeof(Position))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetPosition(int PositionId)
        {
            if (!_PositionRepository.PositionExsists(PositionId))
            {
                return NotFound("Postion Does Not Exsist");
            }
            var position = _PositionRepository.GetPosition(PositionId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(position);
        }

        //api/positions
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Position>))]
        public IActionResult GetPositions()
        {
            var postios = _PositionRepository.GetPositions();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(postios);
        }

        //api/positions
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Position))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreatePosition ([FromBody]Position position)
        {
            if (position == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_PositionRepository.CreatePosition(position))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetPosition", new { positionId = position.PositionId }, position);
        }


        // Update is not implemented.
        //api/authors/authorId
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [HttpDelete("{positionId}")]
        public IActionResult DeletePosition(int PositionId)
        {
            if (!_PositionRepository.PositionExsists(PositionId))
            {
                return NotFound();
            }
            var positionToDelete = _PositionRepository.GetPosition(PositionId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_PositionRepository.DeletePosition(positionToDelete))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}