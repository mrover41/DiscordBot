using DSharpPlus;

namespace DisLoader;

public sealed class DiscordConfiguration {
    public string Token { get; set; }
    public TokenType TokenType { get; set; }
    public DiscordIntents Intents { internal get; set; } = DiscordIntents.AllUnprivileged;
}