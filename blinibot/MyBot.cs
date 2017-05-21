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
            
            //Whenever a message is sent by someone who isn't a bot, catalogue it for use with !phrase. Also avoids fullwidth text because it may have been messing with !phrase
            _client.MessageReceived += (s, e) =>
            {
                if (!e.Message.IsAuthor && !e.Message.User.IsBot)
                {
                    phraseCom.Catalogue(e.Message.Text);
                }
            };

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect("MzE1MDA5MjgxNzMwNjc0Njg4.DAAirw.cWcnSN2K2aCYqGu7YGlB8H8_RRs", TokenType.Bot);
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
