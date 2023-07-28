using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SpectreMT;

public class MyHostedService : IHostedService
{
    private readonly IBus _bus;
    private readonly ILogger<MyHostedService> _logger;

    public MyHostedService(IBus bus, ILogger<MyHostedService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending");
        await _bus.Publish(
            new MyMessage()
            {
                Body = "dave"
            }
        );
        _logger.LogInformation("Sent");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}