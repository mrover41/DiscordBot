using DisCore.Features.CommandSystem.Containers.Configs;

namespace DisCommands.Config;

public class TestCommandConfig {
    public static CommandConfig Config { get; set; } = new CommandConfig() {
        Name = "tst",
        Description = "TestCommand",
        ID = "test",
    };
}