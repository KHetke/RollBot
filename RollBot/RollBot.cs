/***************
 * Kamran Hetke
 * 10/4/2016 (Initial Creation)
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
        CommandService commands;

        public RollBot()
        {
            /* Settings */
            char commandCharacter = '!'; // This character is used to give RollBot Commands
            /************/

            /* Bot Configuration */
            discord = new DiscordClient(x =>
                {
                    // Logs various activities to the console
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = Log;
                });

            discord.UsingCommands(x => 
                {
                    // Sets the method for using commands
                    x.PrefixChar = commandCharacter;
                    x.AllowMentionPrefix = true;
                });

            commands = discord.GetService<CommandService>(); // Initialize the discord.net command service
            /*********************/

            /* Command Registry */
            // !hello says hello!
            RegisterHelloCommand();
            // !roll rolls dice within a range of 1-1000
            RegisterRollCommand();
            /********************/

            /* Connect To Discord */
            discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect("", TokenType.Bot); // Put your token here
                });
            /**********************/
        }

        /* Commands */
        private void RegisterHelloCommand()
        {
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    Console.WriteLine("!Hello"); // Logs the command used to the console
                    await e.Channel.SendTTSMessage("Hello!");
                });
        }
        private void RegisterRollCommand()
        {
            commands.CreateCommand("roll")
                .Parameter("dieParameters") // Parameters following the !roll command are stored in "dieParameters"
                .Do(async (e) =>
                {
                    string dieParameters = e.GetArg("dieParameters"); 
                    Console.WriteLine("!roll " + dieParameters); // Logs the command used to the console
                    Roll roll = new Roll(dieParameters);
                    Console.WriteLine("Roll total is " + roll.total); // Logs the die roll to the console
                    await e.Channel.SendMessage("Roll = " + roll.total);
                });
        }

        /* Log to Console */
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
