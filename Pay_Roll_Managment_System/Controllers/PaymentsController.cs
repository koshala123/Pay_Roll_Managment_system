using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay_Roll_Managment_System.BuisnessLogic;

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


    }
}