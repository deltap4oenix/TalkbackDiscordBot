using System;
using System.Collections.Generic;
using Xunit;

namespace DiscordSmackTalkingBot.Tests
{
    public class SmackTalkServiceTests
    {
        [Fact]
        public void GetRandomSmackTalk_ReturnsNonEmptyString()
        {
            var service = new SmackTalkService();

            var result = service.GetRandomSmackTalk();

            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public void GetRandomSmackTalk_ReturnsNonNullString()
        {
            var service = new SmackTalkService();

            var result = service.GetRandomSmackTalk();

            Assert.NotNull(result);
        }

        [Fact]
        public void SmackTalkCount_ReturnsPositiveNumber()
        {
            Assert.True(SmackTalkService.SmackTalkCount > 0);
        }

        [Fact]
        public void GetRandomSmackTalk_WithSeededRandom_ReturnsDeterministicResult()
        {
            var random1 = new Random(42);
            var random2 = new Random(42);
            var service1 = new SmackTalkService(random1);
            var service2 = new SmackTalkService(random2);

            var result1 = service1.GetRandomSmackTalk();
            var result2 = service2.GetRandomSmackTalk();

            Assert.Equal(result1, result2);
        }

        [Fact]
        public void GetRandomSmackTalk_CalledMultipleTimes_ReturnsVariety()
        {
            var service = new SmackTalkService();
            var results = new HashSet<string>();

            for (int i = 0; i < 100; i++)
            {
                results.Add(service.GetRandomSmackTalk());
            }

            Assert.True(results.Count > 1, "Expected multiple different smack talk responses");
        }

        [Fact]
        public void GetRandomSmackTalk_AllResultsAreFromKnownList()
        {
            var service = new SmackTalkService();

            for (int i = 0; i < 50; i++)
            {
                var result = service.GetRandomSmackTalk();
                Assert.Contains(result, GetExpectedSmackTalkList());
            }
        }

        private static IEnumerable<string> GetExpectedSmackTalkList()
        {
            return new[]
            {
                "I'd agree with you but then we'd both be wrong.",
                "You're not stupid; you just have bad luck thinking.",
                "I'd explain it to you, but I left my crayons at home.",
                "If I wanted to kill myself, I'd climb your ego and jump to your IQ.",
                "You're the reason the gene pool needs a lifeguard.",
                "I've been called worse things by better people.",
                "You bring everyone so much joy when you leave.",
                "If you were any more inbred, you'd be a sandwich.",
                "I'm not saying I hate you, but I would unplug your life support to charge my phone.",
                "You're like a cloud. When you disappear, it's a beautiful day.",
                "Somewhere out there is a tree tirelessly producing oxygen for you. You owe it an apology.",
                "You're not the dumbest person in the world, but you better hope they don't die.",
                "If brains were dynamite, you wouldn't have enough to blow your nose.",
                "You're proof that evolution can go in reverse.",
                "I'd call you a tool, but that would imply you're useful.",
                "You have the charisma of a wet sock.",
                "I'm jealous of people who haven't met you.",
                "You're like a software update. When I see you, I think 'not now.'",
                "If ignorance is bliss, you must be the happiest person alive.",
                "You're the human equivalent of a participation trophy.",
                "I'd roast you, but my mom said I'm not allowed to burn trash.",
                "You're not pretty enough to be this stupid.",
                "I treasure the time I don't spend with you.",
                "Were you born on a highway? That's where most accidents happen.",
                "I'm not insulting you, I'm describing you."
            };
        }
    }
}
