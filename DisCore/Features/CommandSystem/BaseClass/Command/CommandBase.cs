using DisCore.Features.CommandSystem.BaseClass.AccessCondition;
using DisCore.Features.CommandSystem.Containers.Configs;
using DSharpPlus;
using DSharpPlus.Entities;

namespace DisCore.Features.CommandSystem.BaseClass.Command;

public abstract class CommandBase {
    protected static List<DiscordMember> Members = new();

    public CommandBase(CommandConfig config) {
        Config = config;
    }
    
    public readonly CommandConfig Config;
    public readonly List<AccessConditionBase> AccessConditions = new();

    internal void RunCommand(DiscordMember member, string[] args) {
        foreach (AccessConditionBase condition in AccessConditions) {
            if (!condition.CheckAccess(member, args)) return;
        }
        
        OnRun(member, args);
    }

    internal void EndCommand(DiscordMember member) {
        OnEnd(member);
    }

    protected virtual void OnRun(DiscordMember member, string[] args) {
        
    }

    protected virtual void OnEnd(DiscordMember member) {
        
    }
}