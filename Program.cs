using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Reactive.Subjects;
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

            this.client.Log += LogFuncAsync;
            await this.client.LoginAsync(Discord.TokenType.Bot, token);
            await this.client.StartAsync();
            await Task.Delay(-1);

            async Task LogFuncAsync(Discord.LogMessage message) =>
              Console.Write(message.ToString());
        }

        private async Task MessageHandler(SocketMessage message)
        {
            if (message.Author.IsBot)
                return;
            if (message.MentionedUsers.Any(u => u.Id == client.CurrentUser.Id))
            {
              await ReplyAsync(message, smackTalkService.GetRandomSmackTalk());
            }
        }

        private async Task ReplyAsync(SocketMessage message, string response) =>
          await message.Channel.SendMessageAsync(response);

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Smack Talk Bot...");
            new Program().StartBotAsync().GetAwaiter().GetResult();
        }
    }
}
