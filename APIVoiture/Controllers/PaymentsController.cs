using Microsoft.AspNetCore.Mvc;
using Stripe;
namespace APIVoiture.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpPost("create-payment-intent")]
        public IActionResult CreatePaymentIntent([FromBody] PaymentIntentCreateRequest request)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = request.Amount, // Valor em centavos
                Currency = "brl",         // Moeda 
                PaymentMethodTypes = new List<string> { "card" }, // Método de pagamento
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", request.OrderId }
                }
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return Ok(new
            {
                clientSecret = paymentIntent.ClientSecret 
            });
        }
    }

    public class PaymentIntentCreateRequest
    {
        public long Amount { get; set; }
        public string OrderId { get; set; }
    }
}