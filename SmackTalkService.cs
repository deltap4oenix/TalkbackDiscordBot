using System;

namespace DiscordSmackTalkingBot
{
    public class SmackTalkService
    {
        private readonly Random random;

        private static readonly string[] smackTalk = new string[]
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

        public SmackTalkService() : this(new Random())
        {
        }

        public SmackTalkService(Random random)
        {
            this.random = random;
        }

        public string GetRandomSmackTalk()
        {
            return smackTalk[random.Next(smackTalk.Length)];
        }

        public static int SmackTalkCount => smackTalk.Length;
    }
}
