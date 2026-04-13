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
        string input = ev.Message.Content;
        string[] parts = input.Split(' ', 2);
        if (ev.Message.Content.First() == '!')
            CommandManager.ExecuteCommand((DiscordMember)ev.Author, parts[0].Substring(1), parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }
    
    public override void OnDisable() {
        //Program.builder.ConfigureEventHandlers(x => x.HandleMa);
        base.OnDisable();
    }
}