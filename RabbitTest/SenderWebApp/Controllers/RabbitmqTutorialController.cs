using CommonWork;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using System.Net.Mail;
using System.Net;

namespace SenderWebApp.Controllers
{

    [Route("api")]
    [ApiController]
    public class RabbitmqTutorialController : ControllerBase
    {
        private readonly MassTransit.IBus _bus;
        private readonly IRequestClient<BalanceUpdate> _client;

        public RabbitmqTutorialController(MassTransit.IBus bus , IRequestClient<BalanceUpdate> client)
        {
            _bus = bus;
            _client = client;
        }
        // command send part
        [HttpPost("send-tutoria")]
        public async Task<IActionResult> Test1() 
        {
            var product = new product("computer", 50);

            var url = new Uri("rabbitmq://localhost/send-tutorial");
            var endpoint = await _bus.GetSendEndpoint(url);
            await endpoint.Send(product);

            return Ok("hello command send tutorial");
        }
        [HttpPost("publish-tutorial")]
        public async Task<IActionResult> Test2()
        {
            await _bus.Publish(new Person("Dennis", "dennis@gmail.com"));//Task
            return Ok("publish tutorial part done");
        }
        [HttpPost("request-tutorial")]
        public async Task<IActionResult> Test3()
        {
            var requestData = new BalanceUpdate("minus Amount", 50);
         


            var request =  _client.Create(requestData);
            var response = await request.GetResponse<NowBalance>();

            return Ok(response);

        }

        [HttpPost("send-mail")]
        public async Task<ActionResult> Test4()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("denisn@gmail.com", "zqcmlzicaammgzso"),
                EnableSsl = true,
            };
            try
            {
                smtpClient.Send("cariluslinnaeus@gmail.comm", "oselucarilus1@gmail.com", "HELLO", "Hello World");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();

        }
    }
}
