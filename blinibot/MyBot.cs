using Discord;
using Discord.Commands;

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blinibot
{
    class MyBot
    {
        DiscordClient _client;
        CommandService commands;

        Random rand;

        string[] blinis;
        Dictionary<string, word> phraseLibrary = new Dictionary<string, word>();

        public MyBot()
        {
            rand = new Random();
            blinis = new string[]
            {
                "blinis/blini1.jpg",
                "blinis/blini2.jpg",
                "blinis/blini3.jpg",
                "blinis/blini4.jpg",
                "blinis/blini5.jpg",
                "blinis/blini6.jpg",
                "blinis/blini7.jpg",
                "blinis/blini8.JPG",
                "blinis/blini9.jpg",
                "blinis/blini10.PNG",
                "blinis/blini11.jpg",
                "blinis/blini12.PNG",
                "blinis/blini13.JPG",
                "blinis/blini14.PNG",
                "blinis/blini15.jpg",
                "blinis/blini16.jpg",
                "blinis/blini17.jpg",
                "blinis/blini18.JPG",
                "blinis/blini19.JPG",
                "blinis/blini20.JPG",
                "blinis/blini21.jpg",
                "blinis/blini22.jpg",
                "blinis/blini23.jpg",
                "blinis/blini24.jpg",
                "blinis/blini25.jpg",
                "blinis/blini26.jpg",
                "blinis/blini27.jpg",
                "blinis/blini28.jpg",
                "blinis/blini29.jpg",
                "blinis/blini30.jpg",
                "blinis/blini31.jpg",
                "blinis/blini32.jpg",
                "blinis/blini33.PNG",
                "blinis/blini34.png",
                "blinis/blini35.jpg",
                "blinis/blini36.jpg",
                "blinis/blini37.jpg",
                "blinis/blini38.jpg",
                "blinis/blini39.jpg",
                "blinis/blini40.png",
                "blinis/blini41.png",
                "blinis/blini42.png",
                "blinis/blini43.jpg",
                "blinis/blini44.jpg",
                "blinis/blini45.jpg",
                "blinis/blini46.jpg",
                "blinis/blini47.jpg",
                "blinis/blini48.jpg",
                "blinis/blini49.jpg",
                "blinis/blini50.jpg",
                "blinis/blini51.png",
                "blinis/blini52.jpg",
                "blinis/blini53.jpg",
                "blinis/blini54.jpg",
                "blinis/blini55.jpg",
                "blinis/blini56.png",
                "blinis/blini57.png",
                "blinis/blini58.png",
                "blinis/blini59.jpg",
                "blinis/blini60.jpg",
                "blinis/blini61.jpg",
                "blinis/blini62.png",
                "blinis/blini63.png",
                "blinis/blini64.jpg",
                "blinis/blini65.jpg",
                "blinis/blini66.png",
                "blinis/blini67.png",
                "blinis/blini68.jpg",
                "blinis/blini69.png",
                "blinis/blini70.jpg",
                "blinis/blini71.jpg",
                "blinis/blini72.jpg",
                "blinis/blini73.png",
                "blinis/blini74.png",
                "blinis/blini75.jpg",
                "blinis/blini76.png",
                "blinis/blini77.png",
                "blinis/blini78.jpg",
                "blinis/blini79.jpg",
                "blinis/blini80.png",
                "blinis/blini81.jpg",
                "blinis/blini82.jpg",
                "blinis/blini83.jpg",
                "blinis/blini84.jpg",
                "blinis/blini85.jpg",
                "blinis/blini86.jpg",
                "blinis/blini87.jpg",
                "blinis/blini88.jpg",
                "blinis/blini89.jpg",
                "blinis/blini90.jpg",
                "blinis/blini91.png",
                "blinis/blini92.jpg",
                "blinis/blini93.jpg",
                "blinis/blini94.jpg",
                "blinis/blini95.jpg",
                "blinis/blini96.png",
                "blinis/blini97.jpg",
                "blinis/blini98.png",
                "blinis/blini99.jpg",
                "blinis/blini100.jpg",
                "blinis/blini101.jpg",
                "blinis/blini102.png",
                "blinis/blini103.jpg",
                "blinis/blini104.jpg",
                "blinis/blini105.jpg",
                "blinis/blini106.jpg",
                "blinis/blini107.png",
                "blinis/blini108.jpg",
                "blinis/blini109.jpg",
                "blinis/blini110.jpg",
                "blinis/blini111.jpg",
                "blinis/blini112.jpg",
                "blinis/blini113.jpg",
                "blinis/blini114.jpg",
                "blinis/blini115.jpg",
                "blinis/blini116.jpg"
            };

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

            commands = _client.GetService<CommandService>();
            
            _client.MessageReceived += (s, e) =>
            {
                if (!e.Message.IsAuthor && !e.Message.User.IsBot && !((e.Message.Text.Contains("ａ")) || (e.Message.Text.Contains("ｂ")) || (e.Message.Text.Contains("ｃ")) || (e.Message.Text.Contains("ｄ")) || (e.Message.Text.Contains("ｅ")) || (e.Message.Text.Contains("ｆ")) || (e.Message.Text.Contains("ｇ")) || (e.Message.Text.Contains("ｈ")) || (e.Message.Text.Contains("ｉ")) || (e.Message.Text.Contains("ｊ")) || (e.Message.Text.Contains("ｋ")) || (e.Message.Text.Contains("ｌ")) || (e.Message.Text.Contains("ｍ")) || (e.Message.Text.Contains("ｎ")) || (e.Message.Text.Contains("ｏ")) || (e.Message.Text.Contains("ｐ")) || (e.Message.Text.Contains("ｑ")) || (e.Message.Text.Contains("ｒ")) || (e.Message.Text.Contains("ｓ")) || (e.Message.Text.Contains("ｔ")) || (e.Message.Text.Contains("ｕ")) || (e.Message.Text.Contains("ｖ")) || (e.Message.Text.Contains("ｗ")) || (e.Message.Text.Contains("ｘ")) || (e.Message.Text.Contains("ｙ")) || (e.Message.Text.Contains("ｚ")) || (e.Message.Text.Contains("！"))))
                {
                    Catalogue(e.Message.Text);
                }
            };

            RegisterHelpCommand();

            RegisterBliniCommand();

            RegisterBanskiGiggleCommand();

            RegisterPurgeCommand();

            RegisterPhraseCommand();

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect("MjkwMzI0MDE4MzU4MTI0NTU2.C6ZW-Q.ZYRiSz6SnWHE-Go4v2YivU-PSJ4", TokenType.Bot);
                _client.SetGame("Try !blinihelp");
            });
        }

        private void RegisterHelpCommand()
        {
            commands.CreateCommand("blinihelp")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Commands: \n \n !blini [optional number]: Posts a blini. The blini will be random if no number is given. The filename for each posted blini contains what number it is. \n \n !purge [required number]: Deletes the last x messages, where x is the given number. \n \n !phrase: Sends a random message based on what this bot hears.");
                });
        }

        private void Catalogue(string fullMessage)
        {
            fullMessage = fullMessage.ToLower();

            //Trim punctuation and split message into an array of strings
            var punctuation = fullMessage.Where(Char.IsPunctuation).Distinct().ToArray();
            string[] words = fullMessage.Split().Select(x => x.Trim(punctuation)).ToArray();

            if(words.Length > 1)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    //Check if the dictionary already contains the word
                    if (phraseLibrary.ContainsKey(words[i]))
                    {
                        //If there is nothing following the word and it is already in the dictionary, there is nothing to be done
                        if (i < words.Length - 1)
                        {
                            //The word is already in the dictionary, so now we check
                            //if it already has the word following it
                            word addedWord;
                            phraseLibrary.TryGetValue(words[i], out addedWord);
                            //If it does not already have the word following it, add it
                            if (!addedWord.getFollowingWords().Contains(words[i + 1]))
                            {
                                addedWord.addFollowing(words[i + 1]);
                                phraseLibrary[words[i]] = addedWord;
                            }
                            //If it already has it, do nothing
                        }
                    }
                    //If it doesn't exist in the dictionary yet, add it
                    else if(i < words.Length-1)
                    {
                        phraseLibrary.Add(words[i], new word(words[i], words[i + 1]));
                    }
                    else
                    {
                        phraseLibrary.Add(words[i], new word(words[i]));
                    }
                }
            }
        }

        private void RegisterPhraseCommand()
        {
            commands.CreateCommand("phrase")
                .Do(async (e) =>
                {
                    //Initialize an empty string where the message will be stored
                    string phraseToSend = "";
                    //Create list of keys
                    List<string>  keyList = phraseLibrary.Keys.ToList();
                    //Randomly pick a key from the list to be our first word
                    string startingPhrase = keyList[rand.Next(keyList.Count)];
                    //Adds the first word to the phrase
                    phraseToSend += phraseLibrary[startingPhrase].getText();
                    //await e.Channel.SendMessage("Tracing phrase: The current phrase is \"" + phraseToSend + "\"");
                    //5% chance to just be a single word
                    bool addMoreWords = true;
                    if (rand.Next(0, 100) > 95)
                    {
                        addMoreWords = false;
                    }
                    word nextWord;
                    while (addMoreWords)
                    {
                        //Check if there's words following the last one
                        if (!phraseLibrary[startingPhrase].isFollowingEmpty())
                        {
                            //Set nextWord equal to one of the random following words
                            nextWord = phraseLibrary[phraseLibrary[startingPhrase].getRandomFollowing()];
                            //Add the text of nextWord to the string to send
                            phraseToSend += " " + nextWord.getText();
                            //await e.Channel.SendMessage("Tracing phrase: The current phrase is \"" + phraseToSend + "\"");
                            //Shift the starting phrase to the nextWord
                            startingPhrase = nextWord.getText();
                        }
                        else
                        {
                            //Break and send what we have if we run into a dead end
                            break;
                        }
                        if (rand.Next(0, 100) > 95 || phraseToSend.Length >= 600)
                        {
                            //5% chance to stop here and print what we have. Also stops if we go over 600 characters
                            addMoreWords = false;
                        }
                    }
                    await e.Channel.SendMessage(phraseToSend);
                });
        }

        private void RegisterBliniCommand()
        {
            commands.CreateCommand("blini")
                .Parameter("bliniNumber", ParameterType.Optional)
                .Do(async (e) =>
                {
                    if (e.GetArg("bliniNumber").Equals(""))
                        await e.Channel.SendFile(blinis[rand.Next(blinis.Length)]);
                    else
                    {
                        int n;
                        bool isNumeric = int.TryParse(e.GetArg("bliniNumber"), out n);
                        if (!isNumeric)
                            await e.Channel.SendMessage("That's not a number.");
                        else if (n > blinis.Length || n <= 0)
                            await e.Channel.SendMessage("There's no blini of that number! There are currently " + blinis.Length.ToString() + " blinis.");
                        else
                            await e.Channel.SendFile(blinis[n - 1]);
                    }
                });
        }


        private void RegisterBanskiGiggleCommand()
        {
            commands.CreateCommand("makebanskigiggle")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("miscimages/mbg.jpg");
                });
        }

        private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge")
                .Parameter("numberToDelete", ParameterType.Required)
                .Do(async (e) =>
                {
                    //Check if the user is the server owner
                    //Note: Matt Kenney is blacklisted and I gave myself a backdoor to always have access LUL
                    if ((e.User.Id.Equals(e.Server.Owner.Id) && !e.User.Id.ToString().Equals("229396751537143820")) || (e.User.Id.ToString().Equals("189798240923680768")))
                    {
                        Message[] messagesToDelete;
                        int n;
                        bool isNumeric = int.TryParse(e.GetArg("numberToDelete"), out n);
                        //Check if the given argument is an integer and if so, if it's less than 100
                        if (isNumeric && n < 100)
                        {
                            messagesToDelete = await e.Channel.DownloadMessages(n+1);
                            await e.Channel.DeleteMessages(messagesToDelete);
                            await e.Channel.SendMessage("Purged " + e.GetArg("numberToDelete") + " messages!");
                        }
                        else if (isNumeric)
                        {
                            await e.Channel.SendMessage("I can't purge that many messages! I can purge at most 99 messages at a time.");
                        }
                        else
                            await e.Channel.SendMessage("That's not a number.");
                    }
                    else
                        await e.Channel.SendMessage("Only the server owner can call this command!");
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
