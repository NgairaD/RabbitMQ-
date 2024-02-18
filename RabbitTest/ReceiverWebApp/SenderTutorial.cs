using MassTransit;
using System.Threading.Tasks;
using CommonWork;
namespace ReceiverWebApp
{
    public class SenderTutorial: IConsumer<product>
    {
     public async Task Consume(ConsumeContext<product> context)
        {
            var productm = context.Message;
            throw new System.NotImplementedException();

        }
    }
}
 