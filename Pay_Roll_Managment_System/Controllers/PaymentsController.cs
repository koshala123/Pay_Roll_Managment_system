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
    public class PaymentsController : ControllerBase
    {
        private IPaymentRepository _PaymentRepository;

        public PaymentsController(IPaymentRepository PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }

        //api/Payments/PaymentsId
        [HttpGet("{PaymentId}", Name = "GetPayment")]
        [ProducesResponseType(200, Type = typeof(Payment))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetPayment (int PaymentId)
        {
            if (!_PaymentRepository.PaymentExsists(PaymentId))
            {
                return NotFound("Poistion Id is not found");
            }
            var payment = _PaymentRepository.GetPayment(PaymentId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(payment);
        }
        //api/payments
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payment>))]
        public IActionResult GetPayments()
        {
            var payments = _PaymentRepository.GetPayments();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(payments);
        }

        //api/Payments
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Payment))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreatePayment([FromBody]Payment payment)
        {
            if (payment == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_PaymentRepository.CreatePayment(payment))
            {
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetPayment", new { paymentId = payment.Paymentid }, payment);
        }
        //api/payments/paymentID
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [HttpDelete("{PaymentsId}")]
        public IActionResult DeletePayment(int PaymentsId)
        {
            if (!_PaymentRepository.PaymentExsists(PaymentsId))
            {
                return NotFound(PaymentsId);
            }
            var paymentToDelete = _PaymentRepository.GetPayment(PaymentsId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_PaymentRepository.DeletePayment(paymentToDelete))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        //api/payments/paymentsId
        [HttpPut("{paymentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdatePayment(int paymentId,[FromBody]Payment paymentToUpdate)
        {
            if (paymentToUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (!_PaymentRepository.PaymentExsists(paymentId))
            {
                ModelState.AddModelError("", "payment doesnt exsist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_PaymentRepository.UpdatePayment(paymentToUpdate))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}