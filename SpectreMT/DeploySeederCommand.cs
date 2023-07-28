using MassTransit;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using ValidationResult = Spectre.Console.ValidationResult;

public class DeploySeederCommand : AsyncCommand<DeploySeederCommand.DeploySeederCommandCommandSettings>
{
    private readonly ILogger<DeploySeederCommand> _logger;
    private readonly IBus _bus;

    public DeploySeederCommand(ILogger<DeploySeederCommand> logger, IBus bus)
    {
        _bus = bus;
        _logger = logger;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, DeploySeederCommandCommandSettings settings)
    {
        //await _bus.Publish(new MyMessage { Body = "test" });
        return 0;
    }

    public class DeploySeederCommandCommandSettings : CommandSettings
    {
        [CommandOption("-t|--tenant <TENANT>")]
        public string Tenant { get; set; } = null!;

        public override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(Tenant))
            {
                return ValidationResult.Error("Tenant must be passed in");
            }

            return base.Validate();
        }
    }
}