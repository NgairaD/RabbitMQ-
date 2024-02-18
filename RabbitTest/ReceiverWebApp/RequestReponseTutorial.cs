using CommonWork;
using MassTransit;

namespace ReceiverWebApp
{
    public class RequestReponseTutorial : IConsumer<BalanceUpdate>
    {
        private object BalanceUpdate;

        public async Task Consume(ConsumeContext<BalanceUpdate> Context)
        {
            BalanceUpdate = Context.Message;

            var nowBalance = new NowBalance(100);

            await Context.RespondAsync<NowBalance>(nowBalance);

        }
    }
}
