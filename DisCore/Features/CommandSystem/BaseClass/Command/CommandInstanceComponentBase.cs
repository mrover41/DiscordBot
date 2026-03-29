using DSharpPlus;
using DSharpPlus.Entities;

namespace DisCore.Features.CommandSystem.BaseClass.Command;

public abstract class CommandInstanceComponentBase {
    public CommandBase Command { get; }

    public readonly DiscordMember Member;

    CommandInstanceComponentBase(CommandBase command, DiscordMember member) {
        Command = command;
        Member = member;
    }

    public virtual void OnAdd() {}
    
    public virtual void OnRemove() {}
}