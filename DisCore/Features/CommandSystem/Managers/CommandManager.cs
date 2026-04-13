using System.Reflection;
using DisCore.Features.CommandSystem.Attributies;
using DisCore.Features.CommandSystem.BaseClass.Command;
using DSharpPlus.Entities;

namespace DisCore.Features.CommandSystem.BaseClass.Managers;

public static class CommandManager {
    internal static readonly Dictionary<string, CommandBase> Commands = new();
    public static readonly Dictionary<DiscordMember, CommandInstanceComponentBase> CommandInstances = new();

    public static void RegisterAllCommands(Assembly assembly) {
        foreach (Type type in assembly.GetTypes().Where(x => x.GetCustomAttribute<LoadCommandAttribute>() != null)) {
            CommandBase command = Activator.CreateInstance(type) as CommandBase;
            
            if (command == null) break;
            
            Commands.Add(command.Config.ID, command);
        }
    }

    public static void ExecuteCommand(this DiscordMember member, string id, string[] args) {
        CommandBase command = Commands[id];
        
        if (command == null) return;
        
        Type type = command.GetType().GetCustomAttribute<LoadCommandAttribute>().ComponentType;
        
        CommandInstanceComponentBase instanceComponent = (CommandInstanceComponentBase)Activator.CreateInstance(type, command, member);
        
        command.RunCommand(member, args);
        instanceComponent.OnAdd();
        
        CommandInstances.Add(member, instanceComponent);
    }
    
    public static void EndCommand(this DiscordMember member) {
        for (;;) {
            CommandInstanceComponentBase commandInstance = CommandInstances.TryGetValue(member, out var com) ? com : null;
            
            if (commandInstance == null) return;
            
            commandInstance.OnRemove();
            commandInstance.Command.EndCommand(member);
            
            CommandInstances.Remove(member);
        }
    }

    public static CommandInstanceComponentBase GetCommandInstance(this DiscordMember member) {
        return CommandInstances.TryGetValue(member, out var com) ? com : null;
    }
}