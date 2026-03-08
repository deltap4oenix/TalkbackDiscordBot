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
        private const string token = "850ead54a3799c07ce23ed49d72bd64295aba032e61b9d3715fc91287e7572a0";

        public Program()
        {
            this.client = new DiscordSocketClient();
            this.smackTalkService = new SmackTalkService();
            this.client.MessageReceived += MessageHandler;
        }

        public async Task StartBotAsync()
        {
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
