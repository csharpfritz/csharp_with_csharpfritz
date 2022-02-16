using DSharpPlus;

namespace FirstBot;

public static class DiscordExtensions {

    private static FritzBot _Bot;

    public static DiscordClient AddFritzBot(this DiscordClient client)
    {

        _Bot = new FritzBot();
        _Bot.Initialize(client);

        return client;

    }

}