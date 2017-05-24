using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace blinibot
{
    class PhraseCommands
    {
        Random rand;

        Dictionary<string, word> phraseLibrary = new Dictionary<string, word>();

        public PhraseCommands(CommandService cmd)
        {
            RegisterCommands(cmd);

            rand = new Random();
        }

        //Function to add words in a given message to the dictionary used in !phrase
        public void Catalogue(string fullMessage)
        {
            //Trim punctuation and split message into an array of strings
            var punctuation = fullMessage.Where(Char.IsPunctuation).Distinct().ToArray();
            string[] words = fullMessage.Split().Select(x => x.Trim(punctuation)).ToArray();

            //Put the first word to lowercase unless it's a youtube url
            if (words[0].Length > 11)
            {
                if (!words[0].Contains("youtube.com"))
                {
                    words[0] = words[0].ToLower();
                }
            }
            else
            {
                words[0] = words[0].ToLower();
            }

            //For multiple words
            if (words.Length > 1)
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
                                //Put the next word to lowercase unless it's a youtube url
                                if (words[i + 1].Length > 11)
                                {
                                    if (!words[i + 1].Contains("youtube.com"))
                                    {
                                        words[i + 1] = words[i + 1].ToLower();
                                    }
                                }
                                else
                                {
                                    words[i + 1] = words[i + 1].ToLower();
                                }
                                addedWord.addFollowing(words[i + 1]);
                                phraseLibrary[words[i]] = addedWord;
                            }
                            //If it already has it, do nothing
                        }
                    }
                    //If it doesn't exist in the dictionary yet, add it
                    else if (i < words.Length - 1)
                    {
                        phraseLibrary.Add(words[i], new word(words[i], words[i + 1]));
                    }
                    else
                    {
                        phraseLibrary.Add(words[i], new word(words[i]));
                    }
                }
            }
            //For if we just have to catalogue one word
            else
            {
                //As we're not updating the following words, we just have to check if it already contains the word. If it doesn't, add it. Else, do nothing
                if (!phraseLibrary.ContainsKey(words[0]))
                {
                    phraseLibrary.Add(words[0], new word(words[0]));
                }
            }
        }

        private void RegisterCommands(CommandService cmd)
        {
            cmd.CreateCommand("phrase")
                .Description("Sends a random phrase based on the words catalogued by Catalogue()")
                .Do(async (e) =>
                {
                    //Initialize an empty string where the message will be stored
                    string phraseToSend = "";
                    //Create list of keys
                    List<string> keyList = phraseLibrary.Keys.ToList();
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
                    //Send the message
                    await e.Channel.SendMessage(phraseToSend);
                });
            
            cmd.CreateCommand("following")
                .Description("Sends all the words that can follow the given word")
                .Parameter("wordToCheck", ParameterType.Required)
                .Do(async (e) =>
                {
                    //Checks if the given word is in the phraseLibrary to begin with
                    if (phraseLibrary.ContainsKey(e.GetArg("wordToCheck")))
                    {
                        //Saves the word we have to check to a variable so we don't have to keep doing GetArg()
                        string checkWord = e.GetArg("wordToCheck");
                        if(phraseLibrary[checkWord].getFollowingWords().Count() == 0)
                        {
                            await e.Channel.SendMessage("This word is in the library but it has no words that follow it");
                        }
                        //Only one word can 
                        else if (phraseLibrary[checkWord].getFollowingWords().Count() == 1)
                        {
                            await e.Channel.SendMessage("Words that can follow " + checkWord + ": " + phraseLibrary[checkWord].getRandomFollowing());
                        }
                        else
                        {
                            //Start the string that will be our final message
                            string messageToSend = "Words that can follow " + checkWord + ": ";
                            List<string> following = phraseLibrary[checkWord].getFollowingWords();
                            messageToSend += following[0];
                            for (int i = 1; i < following.Count(); i++)
                            {
                                messageToSend += ", " + following[i];
                            }
                            await e.Channel.SendMessage(messageToSend);
                        }
                    }
                    //Realistically this should never come up, as it should be entered into the phraseLibrary when this command is called unless it's a blacklisted word
                    else
                    {
                        await e.Channel.SendMessage("This word is not stored");
                    }
                });

            //WIP saving and loading

            /*
            cmd.CreateCommand("save")
                .Description("Writes the phraseLibrary dictionary to a file so that it can be loaded later")
                .Do(async (e) =>
                {
                    //Only I (chainsauce) can use this command
                    if(e.User.Id.ToString().Equals("189798240923680768"))
                    {
                        await e.Channel.SendMessage("Saved phrase library to file!");
                    }
                });
            
            cmd.CreateCommand("load")
                .Description("Loads the phraseLibrary dictionary from a file")
                .Do(async (e) =>
                {
                    //Only I (chainsauce) can use this command
                    if (e.User.Id.ToString().Equals("189798240923680768"))
                    {
                        await e.Channel.SendMessage("Loaded phrase library from file!");
                    }
                });
                */
        }
    }
}
