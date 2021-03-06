﻿using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blinibot
{
    class BotCommands
    {
        Random rand;

        string[] blinis;

        public BotCommands(CommandService cmd)
        {
            rand = new Random();

            RegisterCommands(cmd);

            //Array of blini image names for use with the !blini command
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
                "blinis/blini86.png",
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
                "blinis/blini116.jpg",
                "blinis/blini117.jpg",
                "blinis/blini118.jpg",
                "blinis/blini119.jpg",
                "blinis/blini120.jpg",
                "blinis/blini121.jpg",
                "blinis/blini122.jpg",
                "blinis/blini123.jpg",
                "blinis/blini124.jpg",
                "blinis/blini125.jpg",
                "blinis/blini126.jpg",
                "blinis/blini127.png",
                "blinis/blini128.png",
                "blinis/blini129.png",
                "blinis/blini130.png",
                "blinis/blini131.jpg",
                "blinis/blini132.jpg",
                "blinis/blini133.jpg",
                "blinis/blini134.jpg",
                "blinis/blini135.png",
                "blinis/blini136.png",
                "blinis/blini137.jpg",
                "blinis/blini138.jpg",
                "blinis/blini139.jpg",
                "blinis/blini140.jpg",
                "blinis/blini141.jpg",
                "blinis/blini142.jpg",
                "blinis/blini143.jpg",
                "blinis/blini144.jpg",
                "blinis/blini145.jpg",
                "blinis/blini146.jpg",
                "blinis/blini147.jpg",
                "blinis/blini148.jpg",
                "blinis/blini149.jpg",
                "blinis/blini150.jpg",
                "blinis/blini151.jpg",
                "blinis/blini152.jpg",
                "blinis/blini153.jpg",
                "blinis/blini154.png",
                "blinis/blini155.jpg",
                "blinis/blini156.jpg",
                "blinis/blini157.jpg",
                "blinis/blini158.jpg",
                "blinis/blini159.jpg"
            };
        }

        private void RegisterCommands(CommandService cmd)
        {
            cmd.CreateCommand("blinihelp")
                .Description("Send a message describing all the commands")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Commands: \n \n !blini [optional number]: Posts a blini. The blini will be random if no number is given. The filename for each posted blini contains what number it is. \n \n !purge [required number]: Deletes the last x messages, where x is the given number. \n \n !phrase [optional word]: Sends a random message based on what this bot hears. If you give it a word, it will start it's phrase with that word.");
                });
            
            cmd.CreateCommand("blini")
                .Description("Sends a random image of blini (the cat)")
                .Parameter("bliniNumber", ParameterType.Optional)
                .Do(async (e) =>
                {
                    //If no number is given, send a random blini
                    if (e.GetArg("bliniNumber").Equals(""))
                        await e.Channel.SendFile(blinis[rand.Next(blinis.Length)]);
                    //Otherwise send the chosen blini
                    else
                    {
                        int n;
                        //Check if the argument is a valid number
                        bool isNumeric = int.TryParse(e.GetArg("bliniNumber"), out n);
                        if (!isNumeric)
                            await e.Channel.SendMessage("That's not a number.");
                        else if (n > blinis.Length || n < -1)
                            await e.Channel.SendMessage("There's no blini of that number! There are currently " + blinis.Length.ToString() + " blinis.");
                        else if(n == 0)
                        {
                            if (rand.Next(2) == 1)
                                await e.Channel.SendFile("blinis/bliniDream1.jpg");
                            else
                                await e.Channel.SendFile("blinis/bliniDream2.jpg");
                        }
                        else if (n == -1)
                            await e.Channel.SendFile("blinis/bliniGlitch.gif");
                        else
                            await e.Channel.SendFile(blinis[n - 1]);
                    }
                });
            
            cmd.CreateCommand("makebanskigiggle")
                .Description("Send the image mbg.jpg")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("miscimages/mbg.jpg");
                });
            
            cmd.CreateCommand("purge")
                .Description("Delete the last X messages in chat, where X is the given number")
                .Parameter("numberToDelete", ParameterType.Required)
                .Do(async (e) =>
                {
                    //Check if the user is the server owner
                    if (e.User.Id.Equals(e.Server.Owner.Id))
                    {
                        Message[] messagesToDelete;
                        int n;
                        bool isNumeric = int.TryParse(e.GetArg("numberToDelete"), out n);
                        //Check if the given argument is an integer and if so, if it's less than 100
                        if (isNumeric && n < 100)
                        {
                            messagesToDelete = await e.Channel.DownloadMessages(n + 1);
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
    }
}