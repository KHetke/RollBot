/***************
 * Kamran Hetke
 * 10/4/2016
 * RollBot > RollBot.cs
 ***************/

/* Discord Specific */
using Discord;
using Discord.Commands;

/* System */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollBot
{
    class RollBot
    {
        DiscordClient discord;

        public RollBot()
        {
            /* Settings */
            char commandCharacter = '!'; // This is the character used to give RollBot Commands
            /************/

            /* Bot Configuration */
            discord = new DiscordClient(x =>
                {
                    // Logs data to the console
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = Log;
                });

            discord.UsingCommands(x =>
                {
                    x.PrefixChar = commandCharacter;
                    x.AllowMentionPrefix = true;
                });

            var commands = discord.GetService<CommandService>();
            /*********************/


            /* Commands */
            // !spooky gives a creative insult to "Spooky"
            commands.CreateCommand("hello")
                .Do(async (e) =>
                    {
                        await e.Channel.SendTTSMessage("Hello!");
                    });

            /************/


            /* Connect To Discord */
            discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect("", TokenType.Bot); // Your token here
                });
            /**********************/

        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
