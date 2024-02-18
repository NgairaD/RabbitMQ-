using MassTransit;
using ReceiverWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq((context, config) =>
    {
        config.Host(new Uri("rabbitmq://localhost:5672"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ReceiveEndpoint("send-tutorial", e =>
        {
            e.Consumer<SenderTutorial>();
        });
        config.ReceiveEndpoint("publish-tutorial", e =>
        {
            e.Consumer<SenderTutorial>();
        });
        config.ReceiveEndpoint("request-tutorial", e =>
        {
            e.Consumer<SenderTutorial>();
        });
        config.ReceiveEndpoint("send-mail", e =>
        {
            e.Consumer<SenderTutorial>();
        });
    }
    );
    
    x.AddConsumer<SenderTutorial>();
    x.AddConsumer<PublisherTutorial>();
    x.AddConsumer<RequestReponseTutorial>();


});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

