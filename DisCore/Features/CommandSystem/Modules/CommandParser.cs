using DisCore.Features.CommandSystem.BaseClass.Managers;
using DisCore.Features.ModuleSystem.Attributies;
using DisCore.Features.ModuleSystem.BaseClass;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace DisCore.Features.CommandSystem.Modules;

[LoadModule]
public class CommandParser : ModuleBase {
    public override void OnEnable() {
        Program.builder.ConfigureEventHandlers(x => x.HandleMessageCreated(CreatedMessage));
        base.OnEnable();
    }
    
    private async Task CreatedMessage(DiscordClient client, MessageCreatedEventArgs ev) {
        Console.WriteLine($"[INFO] {ev.Message}");
        
        string input = ev.Message.Content;
        
        if (input[0] != '!') return;
        
        string[] parts = input.Split(' ', 2);
        string[] args = new string[parts.Length - 1];
        
        if (parts[1] != null) args = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (ev.Message.Content.First() == '!')
            CommandManager.ExecuteCommand((DiscordMember)ev.Author, parts[0].Substring(1), args);
        
        Console.WriteLine("[DISCORE] Command: " + input);
    }
    
    public override void OnDisable() {
        //Program.builder.ConfigureEventHandlers(x => x.HandleMa);
        base.OnDisable();
    }
}