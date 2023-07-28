using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;
using Spectre.Console.Extensions.Hosting;


await Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(
        services =>
        {
            services.AddMassTransit(x =>
            {
                // elided ...
                x.UsingInMemory();
            });

            //services.AddHostedService<MyHostedService>();
        }
    )
    .UseConsoleLifetime()
    .UseSpectreConsole(
        c =>
        {
            c.AddSeederCommands();

            c.PropagateExceptions();
        }
    )
    .RunConsoleAsync();

return Environment.ExitCode;