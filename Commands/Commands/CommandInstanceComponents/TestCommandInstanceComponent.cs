using DisCore.Features.CommandSystem.BaseClass.Command;
using DisCore.Features.CommandSystem.BaseClass.Managers;
using DSharpPlus.Entities;

namespace DisCommands.Commands.CommandInstanceComponents;

public class TestCommandInstanceComponent : CommandInstanceComponentBase {
    public TestCommandInstanceComponent(CommandBase command, DiscordMember member) : base(command, member) {
        
    }
    
    public override void OnAdd() {
        Console.WriteLine($"{nameof(TestCommand)} added");
        Member.EndCommand();
        base.OnAdd();
    }

    public override void OnRemove() {
        Console.WriteLine($"{nameof(TestCommand)} removed");
        base.OnRemove();
    }
}