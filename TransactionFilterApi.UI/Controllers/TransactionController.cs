using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionApiFilter.Data.Entities;
using TransactionApiFilter.Data.Repositories;

namespace TransactionFilterApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet("GetByParameter")]
        public IActionResult GetByParameter([FromQuery] TransactionFilterParameters filter)
        {
            var transactions = _transactionRepository.GetByParameter(filter);

            return Ok(transactions);
        }
    }
}
