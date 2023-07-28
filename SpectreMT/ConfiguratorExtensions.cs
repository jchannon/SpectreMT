using Spectre.Console.Cli;

public static class ConfiguratorExtensions
{
    public static void AddSeederCommands(this IConfigurator configurator) =>
        configurator.AddBranch(
            "seeder",
            w =>
            {
                w.AddCommand<DeploySeederCommand>("up")
                    .WithDescription("Seed data into a market.")
                    ;
            }
        );
}