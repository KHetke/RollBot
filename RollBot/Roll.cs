/***************
 * Kamran Hetke
 * 10/7/2016 (Initial Creation)
 * RollBot > Roll.cs
 ***************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollBot
{
    public class Roll
    {
        public int total = 0; // Variable is public so we can call from RollBot.cs
        public Roll(string dieParameters)
        {
            /* Settings */
            char addChar = '+';
            char dieChar = 'd';
            /************/

            dieParameters = dieParameters.Replace(" ", ""); //Remove white space, allowing die rolls such as "1d10 +1 d7 + 5 d10" (Under development)
            string[] dieRolls = dieParameters.Split(addChar); //Split dieParameters into smaller dieRolls chunks

            for (int i = 0; i < dieRolls.Length; i++) //For every dieRolls index position, do the following...
            {
                string[] roll = dieRolls[i].Split(dieChar); // Split the dieRolls further into roll chunks
                if (2 <= roll.Length)
                    //for (int j = 1; j < roll.Length; j++)
                    //{
                    //    Random r = new Random();
                    //    total += r.Next(1, int.Parse(roll[j]) + 1);
                    //}
                    for (int j = 0; j < int.Parse(roll[0]); j++) // Loop the number of times specified in index 1 of roll
                    {
                        for (int k = 1; k < roll.Length; k++) // Loop the length of the roll, catching 1d6d4 type rolls
                        {
                            Random r = new Random();
                            System.Threading.Thread.Sleep(r.Next(1, 5)); // Introduces random sleep time, to prevent identical rolls on each attempt
                            total += r.Next(1, int.Parse(roll[k]) + 1);  // Adds a random number from 1 to the specified
                        }
                    }
                else
                {
                    total += int.Parse(roll[0]); // If a modifier is input, add it to the total
                }
            }

        }
    }
}
