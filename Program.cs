using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordSmackTalkingBot
{
    class Program
    {
        private readonly DiscordSocketClient client;
        private readonly SmackTalkService smackTalkService;

        public Program()
        {
            this.client = new DiscordSocketClient();
            this.smackTalkService = new SmackTalkService();
            this.client.MessageReceived += MessageHandler;
        }

        public async Task StartBotAsync()
        {
            var token = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN")
                ?? throw new InvalidOperationException("DISCORD_BOT_TOKEN environment variable is not set.");

            await this.client.LoginAsync(Discord.TokenType.Bot, token);
            await this.client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageHandler(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;

            if (message.MentionedUsers.Any(u => u.Id == client.CurrentUser.Id))
            {
                await message.Channel.SendMessageAsync(smackTalkService.GetRandomSmackTalk());
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Smack Talk Bot...");
            await new Program().StartBotAsync();
        }
    }
}
