# TalkbackDiscordBot

A Discord bot that responds with witty comebacks when mentioned. Built with .NET 9 and Discord.Net.

## Features

- Responds when mentioned (@bot) in any channel
- Returns a random smack talk response from a curated collection of 25+ witty comebacks
- Ignores messages from other bots

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A Discord Bot Token ([Create one here](https://discord.com/developers/applications))

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/deltap4oenix/TalkbackDiscordBot.git
   cd TalkbackDiscordBot
   ```

2. Set your Discord bot token as an environment variable:

   ```bash
   export DISCORD_BOT_TOKEN="your-bot-token-here"
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the bot:

   ```bash
   dotnet run
   ```

## Usage

1. Invite the bot to your Discord server using the OAuth2 URL from the Discord Developer Portal
2. Mention the bot in any channel: `@YourBotName`
3. Receive a random witty response

## Project Structure

```
TalkbackDiscordBot/
├── Program.cs                 # Bot entry point and message handling
├── SmackTalkService.cs        # Service containing smack talk responses
├── DiscordSmackTalkingBot.csproj
└── DiscordSmackTalkingBot.Tests/
    └── SmackTalkServiceTests.cs
```

## Running Tests

```bash
dotnet test
```

## Dependencies

- [Discord.Net](https://github.com/discord-net/Discord.Net) v3.14.1

## License

This project is open source and available under the MIT License.
