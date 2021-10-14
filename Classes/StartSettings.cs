using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    static class StartSettings
    {
        public static int players {get; set;}
        public static string playerOne { get; set; }
        public static string playerTwo { get; set; }
        public static string playerThree { get; set; }
        public static string playerFour { get; set; }
        public static string playerFive { get; set; }
        public static string playerSix { get; set; }

        /// <summary>
        /// Set player names
        /// </summary>
        /// <param name="Players">amount of players</param>
        /// <param name="PlayerOne"></param>
        /// <param name="PlayerTwo"></param>
        /// <param name="PlayerThree"></param>
        /// <param name="PlayerFour"></param>
        /// <param name="PlayerFive"></param>
        /// <param name="PlayerSix"></param>
        public static void PlayerSettings(int Players, string PlayerOne, string PlayerTwo, string PlayerThree, string PlayerFour, string PlayerFive, string PlayerSix)
        {
            players = Players;
            playerOne = PlayerOne;
            playerTwo = PlayerTwo;
            playerThree = PlayerThree;
            playerFour = PlayerFour;
            playerFive = PlayerFive;
            playerSix = PlayerSix;
        }
    }
}
