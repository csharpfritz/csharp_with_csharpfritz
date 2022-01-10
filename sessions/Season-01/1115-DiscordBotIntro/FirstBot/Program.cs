using DSharpPlus;
using FirstBot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddUserSecrets(typeof(Program).Assembly, true)
    .AddEnvironmentVariables()
    .Build();

DiscordClient discord = new DiscordClient(new DiscordConfiguration {

    AutoReconnect = true,
    MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,

    Token = config["discordtoken"],
    TokenType = TokenType.Bot
});

discord.AddFritzBot();

await discord.ConnectAsync();
await Task.Delay(-1);
