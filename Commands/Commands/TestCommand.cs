using DisCommands.Commands.CommandInstanceComponents;
using DisCommands.Config;
using DisCore.Features.CommandSystem.Attributies;
using DisCore.Features.CommandSystem.BaseClass.Command;
using DisCore.Features.CommandSystem.Containers.Configs;

namespace DisCommands.Commands;

[LoadCommand(typeof(TestCommandInstanceComponent))]
public class TestCommand : CommandBase {
    public TestCommand() : base(TestCommandConfig.Config) {
        Console.WriteLine("[COMMAND] TestCommand");
    }
}