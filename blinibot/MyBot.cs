using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blinibot
{
    class MyBot
    {
        DiscordClient _client;

        public MyBot()
        {
            _client = new DiscordClient(x =>

            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            PhraseCommands phraseCom = new PhraseCommands(_client.GetService<CommandService>());
            InitializeCommands(_client.GetService<CommandService>());
            
            //Whenever a message is sent by someone who isn't a bot, catalogue it for use with !phrase. Certain words and messages from bots are blacklisted from being catalogued
            _client.MessageReceived += (s, e) =>
            {
                if (!e.Message.User.IsBot && !e.Message.Text.Contains("rule34") && !e.Message.Text.Contains("discordapp"))
                {
                    phraseCom.Catalogue(e.Message.Text);
                }
            };

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect("MjkwMzI0MDE4MzU4MTI0NTU2.DDaqWQ.ruQmg3Cymih23fqbK8oXXFx-POM", TokenType.Bot);
                _client.SetGame("try !blinihelp");
            });
        }

        

        //Initializes all the commands
        private void InitializeCommands(CommandService cmd)
        {
            new BotCommands(cmd);
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
